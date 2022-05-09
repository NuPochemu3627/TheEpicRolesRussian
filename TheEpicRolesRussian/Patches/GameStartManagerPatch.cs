  
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using Hazel;
using System;
using UnhollowerBaseLib;

namespace TheEpicRoles.Patches {
    public class GameStartManagerPatch  {
        public static Dictionary<int, PlayerVersion> playerVersions = new Dictionary<int, PlayerVersion>();
        private static float timer = 600f;
        private static float kickingTimer = 0f;
        private static bool versionSent = false;
        private static string lobbyCodeText = "";

        public static string guardianShield = "";

        [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnPlayerJoined))]
        public class AmongUsClientOnPlayerJoinedPatch {
            public static void Postfix() {
                if (PlayerControl.LocalPlayer != null) {
                    Helpers.shareGameVersion();
                }

                // Send current players status list to new player
                if (AmongUsClient.Instance.AmHost) {
                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetReadyNames, Hazel.SendOption.Reliable);
                    writer.WriteBytesAndSize(RPCProcedure.readyStatus.ToArray());
                    writer.EndMessage();
                }
            }
        }


        [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnPlayerLeft))]
        public class AmongUsClientOnPlayerLeftPatch {
            public static void Postfix(AmongUsClient __instance, [HarmonyArgument(0)] ref InnerNet.ClientData data) {      
                // Remove player from ready list and send updated ready status list to all player
                if (AmongUsClient.Instance.AmHost) {
                    RPCProcedure.readyStatus.Remove(data.Character.PlayerId);
                    MessageWriter writer = AmongUsClient.Instance.StartRpc(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetReadyNames, Hazel.SendOption.Reliable);
                    writer.WriteBytesAndSize(RPCProcedure.readyStatus.ToArray());
                    writer.EndMessage();
                    RPCProcedure.setReadyNames(RPCProcedure.readyStatus.ToArray());
                }          
            }
        }

        [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnGameJoined))]
        public class AmongUsClientOnGameJoinedPatch {
            public static void Prefix() {
                // Clear ready status list on game join
                RPCProcedure.readyStatus.Clear();
                TheEpicRolesPlugin.firstKill = 0;
            }
        }

        [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Start))]
        public class GameStartManagerStartPatch {
            public static void Postfix(GameStartManager __instance) {
                if (PlayerControl.GameOptions.MaxPlayers > 15) {
                    PlayerControl.GameOptions.MaxPlayers = 15;
                    PlayerControl.LocalPlayer.RpcSyncSettings(PlayerControl.GameOptions);
                }
                // Trigger version refresh
                versionSent = false;
                // Reset lobby countdown timer
                timer = 600f; 
                // Reset kicking timer
                kickingTimer = 0f;
                // Copy lobby code
                string code = InnerNet.GameCode.IntToGameName(AmongUsClient.Instance.GameId);
                GUIUtility.systemCopyBuffer = code;
                lobbyCodeText = DestroyableSingleton<TranslationController>.Instance.GetString(StringNames.RoomCode, new Il2CppReferenceArray<Il2CppSystem.Object>(0)) + "\r\n" + code;
            }
        }

        [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.Update))]
        public class GameStartManagerUpdatePatch {
            private static bool update = false;
            private static string currentText = "";
            private static TMPro.TextMeshPro vanillaText = null;

            public static void Prefix(GameStartManager __instance) {
                if (!AmongUsClient.Instance.AmHost  || !GameData.Instance ) return; // Not host or no instance
                update = GameData.Instance.PlayerCount != __instance.LastPlayerCount;
            }

            public static void Postfix(GameStartManager __instance) {
                // Send version as soon as PlayerControl.LocalPlayer exists
                if (PlayerControl.LocalPlayer != null && !versionSent) {
                    versionSent = true;
                    Helpers.shareGameVersion();
                }

                // Host update with version handshake infos
                if (AmongUsClient.Instance.AmHost) {
                    bool blockStart = false;
                    bool vanillaMissmatch = false;
                    string message = "";
                    string vanillaMessage = $"<size=70%><color={CredentialsPatch.terColor}>Players with different \nversions of Among Us:</color>\n</size><size=55%>";
                    
                    foreach (InnerNet.ClientData client in AmongUsClient.Instance.allClients.ToArray()) {
                        if (client.Character == null) continue;
                        var dummyComponent = client.Character.GetComponent<DummyBehaviour>();
                        if (dummyComponent != null && dummyComponent.enabled)
                            continue;
                        else if (!playerVersions.ContainsKey(client.Id))  {
                            blockStart = true;
                            message += $"<color=#FF0000FF>{client.Character.Data.PlayerName} has a different or no version of The Epic Roles\n</color>";
                        } else {
                            PlayerVersion PV = playerVersions[client.Id];
                            int diff = TheEpicRolesPlugin.Version.CompareTo(PV.version);
                            if (diff > 0) {
                                message += $"<color=#FF0000FF>{client.Character.Data.PlayerName} has an older version of The Epic Roles (v{playerVersions[client.Id].version.ToString()})\n</color>";
                                blockStart = true;
                            } else if (diff < 0) {
                                message += $"<color=#FF0000FF>{client.Character.Data.PlayerName} has a newer version of The Epic Roles (v{playerVersions[client.Id].version.ToString()})\n</color>";
                                blockStart = true;
                            } else if (!PV.GuidMatches()) { // version presumably matches, check if Guid matches
                                message += $"<color=#FF0000FF>{client.Character.Data.PlayerName} has a modified version of TER v{playerVersions[client.Id].version.ToString()} <size=30%>({PV.guid.ToString()})</size>\n</color>";
                                blockStart = true;
                            }
                            // Vanilla version check, to see if all players are on the same version. Problem: epic and 
                            if (PV.vanillaVersion != Application.version) {
                                vanillaMessage += Helpers.cs(Palette.PlayerColors[client.ColorId], $"{client.Character.Data.PlayerName}: {PV.vanillaVersion}\n");
                                vanillaMissmatch = true;
                            }
                        }
                    }
                    // block start if blockstart is true AND if not all players are ready
                    if (blockStart || (!CustomOptionHolder.toggleLobbyMode.getBool() && RPCProcedure.readyStatus.Count != PlayerControl.AllPlayerControls.Count)) {
                        __instance.StartButton.color = __instance.startLabelText.color = Palette.DisabledClear;
                        __instance.GameStartText.text = message;
                        __instance.GameStartText.transform.localPosition = __instance.StartButton.transform.localPosition + Vector3.up * 2;
                    } else {
                        __instance.StartButton.color = __instance.startLabelText.color = ((__instance.LastPlayerCount >= __instance.MinPlayers) ? Palette.EnabledColor : Palette.DisabledClear);
                        __instance.GameStartText.transform.localPosition = __instance.StartButton.transform.localPosition;
                    }
                    if (vanillaMissmatch) {
                        vanillaMessage += "</size>";
                        if (vanillaText == null) vanillaText = GameObject.Instantiate(__instance.GameStartText, __instance.GameStartText.transform.parent);
                        vanillaText.transform.localPosition = __instance.StartButton.transform.localPosition + new Vector3(4.25f,2.25f,0);
                        vanillaText.alignment = TMPro.TextAlignmentOptions.MidlineLeft;
                        vanillaText.text = vanillaMessage;
                        vanillaText.SetOutlineThickness(0.1f);
                    }
                }

                // Client update with handshake infos
                if (!AmongUsClient.Instance.AmHost) {
                    if (!playerVersions.ContainsKey(AmongUsClient.Instance.HostId) || TheEpicRolesPlugin.Version.CompareTo(playerVersions[AmongUsClient.Instance.HostId].version) != 0) {
                        kickingTimer += Time.deltaTime;
                        if (kickingTimer > 10) {
                            kickingTimer = 0;
			                AmongUsClient.Instance.ExitGame(DisconnectReasons.ExitGame);
                            SceneChanger.ChangeScene("MainMenu");
                        }

                        __instance.GameStartText.text = $"<color=#FF0000FF>The host has no or a different version of The Epic Roles\nYou will be kicked in {Math.Round(10 - kickingTimer)}s</color>";
                        __instance.GameStartText.transform.localPosition = __instance.StartButton.transform.localPosition + Vector3.up * 2;
                    } else {
                        __instance.GameStartText.transform.localPosition = __instance.StartButton.transform.localPosition;
                        if (__instance.startState != GameStartManager.StartingStates.Countdown) {
                            __instance.GameStartText.text = String.Empty;
                        }
                    }
                }

                // Lobby code replacement
                __instance.GameRoomName.text = TheEpicRolesPlugin.StreamerMode.Value ? $"<color={TheEpicRolesPlugin.StreamerModeReplacementColor.Value}>{TheEpicRolesPlugin.StreamerModeReplacementText.Value}</color>" : lobbyCodeText;

                // Lobby timer
                if (!AmongUsClient.Instance.AmHost || !GameData.Instance) return; // Not host or no instance

                if (update) currentText = __instance.PlayerCounter.text;

                timer = Mathf.Max(0f, timer -= Time.deltaTime);
                int minutes = (int)timer / 60;
                int seconds = (int)timer % 60;
                string suffix = $" ({minutes:00}:{seconds:00})";

                __instance.PlayerCounter.text = currentText + suffix;
                __instance.PlayerCounter.autoSizeTextContainer = true;
            }
        }

        [HarmonyPatch(typeof(GameStartManager), nameof(GameStartManager.BeginGame))]
        public class GameStartManagerBeginGame {
            public static bool Prefix(GameStartManager __instance) {
                // Block game start if not everyone has the same mod version
                bool continueStart = true;

                if (AmongUsClient.Instance.AmHost) {
                    foreach (InnerNet.ClientData client in AmongUsClient.Instance.allClients) {
                        if (client.Character == null) continue;
                        var dummyComponent = client.Character.GetComponent<DummyBehaviour>();
                        if (dummyComponent != null && dummyComponent.enabled)
                            continue;
                        
                        if (!playerVersions.ContainsKey(client.Id)) {
                            continueStart = false;
                            break;
                        }
                        
                        PlayerVersion PV = playerVersions[client.Id];
                        int diff = TheEpicRolesPlugin.Version.CompareTo(PV.version);
                        if (diff != 0 || !PV.GuidMatches()) {
                            continueStart = false;
                            break;
                        }
                    }

                    if (CustomOptionHolder.dynamicMap.getBool() && continueStart) {
                        // 0 = Skeld
                        // 1 = Mira HQ
                        // 2 = Polus
                        // 3 = Dleks - deactivated
                        // 4 = Airship
                        List<byte> possibleMaps = new List<byte>();
                        if (CustomOptionHolder.dynamicMapEnableSkeld.getBool())
                            possibleMaps.Add(0);
                        if (CustomOptionHolder.dynamicMapEnableMira.getBool())
                            possibleMaps.Add(1);
                        if (CustomOptionHolder.dynamicMapEnablePolus.getBool())
                            possibleMaps.Add(2);
                        //if (CustomOptionHolder.dynamicMapEnableDleks.getBool())
                        //    possibleMaps.Add(3);
                        if (CustomOptionHolder.dynamicMapEnableAirShip.getBool())
                            possibleMaps.Add(4);
                        byte chosenMapId  = possibleMaps[TheEpicRoles.rnd.Next(possibleMaps.Count)];

                        MessageWriter writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.DynamicMapOption, Hazel.SendOption.Reliable, -1);
                        writer.Write(chosenMapId);
                        AmongUsClient.Instance.FinishRpcImmediately(writer);
                        RPCProcedure.dynamicMapOption(chosenMapId);
                    }

                    // Block start if not all players are ready
                    if (!CustomOptionHolder.toggleLobbyMode.getBool() && RPCProcedure.readyStatus.Count != PlayerControl.AllPlayerControls.Count)
                        continueStart = false;
                }
                return continueStart;
            }
        }

        public class PlayerVersion {
            public readonly Version version;
            public readonly Guid guid;
            public readonly string vanillaVersion;

            public PlayerVersion(Version version, Guid guid, string vanillaVersion) {
                this.version = version;
                this.guid = guid;
                this.vanillaVersion = vanillaVersion;
            }

            public bool GuidMatches() {
                return Assembly.GetExecutingAssembly().ManifestModule.ModuleVersionId.Equals(this.guid);
            }
        }
    }
}
