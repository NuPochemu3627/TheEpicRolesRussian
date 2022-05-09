using System.Collections.Generic;
using UnityEngine;
using BepInEx.Configuration;
using System;
using System.Linq;
using HarmonyLib;
using Hazel;
using System.Reflection;
using System.Text;
using static TheEpicRoles.TheEpicRoles;

namespace TheEpicRoles {
    public class CustomOptionHolder {
        public static string[] rates = new string[]{"0%", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%"};
        public static string[] presets = new string[]{"������ 1", "������ 2", "������ 3", "������ 4", "������ 5"};

        public static CustomOption presetSelection;
        public static CustomOption activateRoles;
        public static CustomOption crewmateRolesCountMin;
        public static CustomOption crewmateRolesCountMax;
        public static CustomOption crewmateRolesMax;
        public static CustomOption neutralRolesCountMin;
        public static CustomOption neutralRolesCountMax;
        public static CustomOption impostorRolesCountMin;
        public static CustomOption impostorRolesCountMax;

        public static CustomOption mafiaSpawnRate;
        public static CustomOption janitorCooldown;

        public static CustomOption morphlingSpawnRate;
        public static CustomOption morphlingCooldown;
        public static CustomOption morphlingDuration;

        public static CustomOption camouflagerSpawnRate;
        public static CustomOption camouflagerCooldown;
        public static CustomOption camouflagerDuration;

        public static CustomOption vampireSpawnRate;
        public static CustomOption vampireKillDelay;
        public static CustomOption vampireCooldown;
        public static CustomOption vampireCanKillNearGarlics;

        public static CustomOption eraserSpawnRate;
        public static CustomOption eraserCooldown;
        public static CustomOption eraserCanEraseAnyone;

        public static CustomOption miniSpawnRate;
        public static CustomOption miniGrowingUpDuration;
        public static CustomOption miniEvilGuessable;

        public static CustomOption loversSpawnRate;
        public static CustomOption loversImpLoverRate;
        public static CustomOption loversBothDie;
        public static CustomOption loversCanHaveAnotherRole;
        public static CustomOption loversEnableChat;
        public static CustomOption loversAliveCount;

        public static CustomOption guesserSpawnRate;
        public static CustomOption guesserIsImpGuesserRate;
        public static CustomOption guesserNumberOfShots;
        public static CustomOption guesserHasMultipleShotsPerMeeting;
        public static CustomOption guesserShowInfoInGhostChat;
        public static CustomOption guesserKillsThroughShield;
        public static CustomOption guesserEvilCanKillSpy;
        public static CustomOption guesserSpawnBothRate;
        public static CustomOption guesserCantGuessSnitchIfTaksDone;

        public static CustomOption jesterSpawnRate;
        public static CustomOption jesterCanCallEmergency;
        public static CustomOption jesterHasImpostorVision;
        public static CustomOption jesterCanBeLawyerClient;

        public static CustomOption arsonistSpawnRate;
        public static CustomOption arsonistCooldown;
        public static CustomOption arsonistDuration;

        public static CustomOption jackalSpawnRate;
        public static CustomOption jackalKillCooldown;
        public static CustomOption jackalCreateSidekickCooldown;
        public static CustomOption jackalCanUseVents;
        public static CustomOption jackalCanCreateSidekick;
        public static CustomOption sidekickPromotesToJackal;
        public static CustomOption sidekickCanKill;
        public static CustomOption sidekickCanUseVents;
        public static CustomOption jackalPromotedFromSidekickCanCreateSidekick;
        public static CustomOption jackalCanCreateSidekickFromImpostor;
        public static CustomOption jackalAndSidekickHaveImpostorVision;

        public static CustomOption bountyHunterSpawnRate;
        public static CustomOption bountyHunterBountyDuration;
        public static CustomOption bountyHunterReducedCooldown;
        public static CustomOption bountyHunterPunishmentTime;
        public static CustomOption bountyHunterShowArrow;
        public static CustomOption bountyHunterArrowUpdateIntervall;

        public static CustomOption witchSpawnRate;
        public static CustomOption witchCooldown;
        public static CustomOption witchAdditionalCooldown;
        public static CustomOption witchCanSpellAnyone;
        public static CustomOption witchSpellCastingDuration;
        public static CustomOption witchTriggerBothCooldowns;
        public static CustomOption witchVoteSavesTargets;

        public static CustomOption shifterSpawnRate;
        public static CustomOption shifterShiftsModifiers;
        public static CustomOption shifterShiftsSelf;
        public static CustomOption shifterDiesBeforeMeeting;

        public static CustomOption mayorSpawnRate;
        public static CustomOption mayorShowVotes;

        public static CustomOption engineerSpawnRate;
        public static CustomOption engineerNumberOfFixes;
        public static CustomOption engineerHighlightForImpostors;
        public static CustomOption engineerHighlightForTeamJackal;

        public static CustomOption sheriffSpawnRate;
        public static CustomOption sheriffCooldown;
        public static CustomOption sheriffCanKillNeutrals;
        public static CustomOption deputySpawnRate;

        public static CustomOption deputyNumberOfHandcuffs;
        public static CustomOption deputyHandcuffCooldown;
        public static CustomOption deputyGetsPromoted;
        public static CustomOption deputyKeepsHandcuffs;
        public static CustomOption deputyHandcuffDuration;
        public static CustomOption deputyKnowsSheriff;

        public static CustomOption lighterSpawnRate;
        public static CustomOption lighterModeLightsOnVision;
        public static CustomOption lighterModeLightsOffVision;
        public static CustomOption lighterCooldown;
        public static CustomOption lighterDuration;

        public static CustomOption detectiveSpawnRate;
        public static CustomOption detectiveAnonymousFootprints;
        public static CustomOption detectiveFootprintIntervall;
        public static CustomOption detectiveFootprintDuration;
        public static CustomOption detectiveReportNameDuration;
        public static CustomOption detectiveReportColorDuration;

        public static CustomOption timeMasterSpawnRate;
        public static CustomOption timeMasterCooldown;
        public static CustomOption timeMasterRewindTime;
        public static CustomOption timeMasterShieldDuration;

        public static CustomOption medicSpawnRate;
        public static CustomOption medicShowShielded;
        public static CustomOption medicShowAttemptToShielded;
        public static CustomOption medicSetShieldAfterMeeting;
        public static CustomOption medicShowAttemptToMedic;

        public static CustomOption swapperSpawnRate;
        public static CustomOption swapperCanCallEmergency;
        public static CustomOption swapperCanOnlySwapOthers;

        public static CustomOption seerSpawnRate;
        public static CustomOption seerMode;
        public static CustomOption seerSoulDuration;
        public static CustomOption seerLimitSoulDuration;

        public static CustomOption hackerSpawnRate;
        public static CustomOption hackerCooldown;
        public static CustomOption hackerHackeringDuration;
        public static CustomOption hackerOnlyColorType;
        public static CustomOption hackerToolsNumber;
        public static CustomOption hackerRechargeTasksNumber;
        public static CustomOption hackerNoMove;

        public static CustomOption trackerSpawnRate;
        public static CustomOption trackerUpdateIntervall;
        public static CustomOption trackerResetTargetAfterMeeting;
        public static CustomOption trackerCanTrackCorpses;
        public static CustomOption trackerCorpsesTrackingCooldown;
        public static CustomOption trackerCorpsesTrackingDuration;

        public static CustomOption snitchSpawnRate;
        public static CustomOption snitchLeftTasksForReveal;
        public static CustomOption snitchIncludeTeamJackal;
        public static CustomOption snitchTeamJackalUseDifferentArrowColor;

        public static CustomOption spySpawnRate;
        public static CustomOption spyCanDieToSheriff;
        public static CustomOption spyImpostorsCanKillAnyone;
        public static CustomOption spyCanEnterVents;
        public static CustomOption spyHasImpostorVision;

        public static CustomOption tricksterSpawnRate;
        public static CustomOption tricksterPlaceBoxCooldown;
        public static CustomOption tricksterPlaceBoxCount;
        public static CustomOption tricksterLightsOutCooldown;
        public static CustomOption tricksterLightsOutDuration;

        public static CustomOption cleanerSpawnRate;
        public static CustomOption cleanerCooldown;
        
        public static CustomOption warlockSpawnRate;
        public static CustomOption warlockCooldown;
        public static CustomOption warlockRootTime;

        public static CustomOption securityGuardSpawnRate;
        public static CustomOption securityGuardCooldown;
        public static CustomOption securityGuardTotalScrews;
        public static CustomOption securityGuardCamPrice;
        public static CustomOption securityGuardVentPrice;
        public static CustomOption securityGuardCamDuration;
        public static CustomOption securityGuardCamMaxCharges;
        public static CustomOption securityGuardCamRechargeTasksNumber;
        public static CustomOption securityGuardNoMove;

        public static CustomOption baitSpawnRate;
        public static CustomOption baitHighlightAllVents;
        public static CustomOption baitReportDelay;
        public static CustomOption baitShowKillFlash;

        public static CustomOption vultureSpawnRate;
        public static CustomOption vultureCooldown;
        public static CustomOption vultureNumberToWin;
        public static CustomOption vultureCanUseVents;
        public static CustomOption vultureShowArrows;

        public static CustomOption mediumSpawnRate;
        public static CustomOption mediumCooldown;
        public static CustomOption mediumDuration;
        public static CustomOption mediumOneTimeUse;

        public static CustomOption lawyerSpawnRate;
        public static CustomOption lawyerTargetKnows;
        public static CustomOption lawyerWinsAfterMeetings;
        public static CustomOption lawyerNeededMeetings;
        public static CustomOption lawyerVision;
        public static CustomOption lawyerKnowsRole;
        public static CustomOption pursuerCooldown;
        public static CustomOption pursuerBlanksNumber;

        public static CustomOption phaserSpawnRate;
        public static CustomOption phaserMarkCooldown;
        public static CustomOption phaserPhaseCooldown;

        public static CustomOption jumperSpawnRate;
        public static CustomOption jumperJumpTime;
        public static CustomOption jumperChargesOnPlace;
        public static CustomOption jumperChargesGainOnMeeting;
        public static CustomOption jumperMaxCharges;

        public static CustomOption maxNumberOfMeetings;
        public static CustomOption blockSkippingInEmergencyMeetings;
        public static CustomOption noVoteIsSelfVote;
        public static CustomOption hidePlayerNames;
        public static CustomOption allowParallelMedBayScans;
      
        public static CustomOption showButtonTarget;
        public static CustomOption randomGameStartPosition;
        public static CustomOption setRoundStartCooldown;
        public static CustomOption firstKillShield;
        public static CustomOption toggleLobbyMode;

        public static CustomOption dynamicMap;
        public static CustomOption dynamicMapEnableSkeld;
        public static CustomOption dynamicMapEnableMira;
        public static CustomOption dynamicMapEnablePolus;
        //public static CustomOption dynamicMapEnableDleks;
        public static CustomOption dynamicMapEnableAirShip;


        internal static Dictionary<byte, byte[]> blockedRolePairings = new Dictionary<byte, byte[]>();

        public static string cs(Color c, string s) {
            return string.Format("<color=#{0:X2}{1:X2}{2:X2}{3:X2}>{4}</color>", ToByte(c.r), ToByte(c.g), ToByte(c.b), ToByte(c.a), s);
        }
 
        private static byte ToByte(float f) {
            f = Mathf.Clamp01(f);
            return (byte)(f * 255);
        }

        public static void Load() {
            
            // Role Options
            presetSelection = CustomOption.Create(0, cs(new Color(0, 1, 217f / 255f, 1f), "������"), "option", presets, null, true);
            activateRoles = CustomOption.Create(1, cs(new Color(0, 1, 217f / 255f, 1f), "�������� ���\n������������� ����������� ����"), "option", true, null, true);

            // Using new id's for the options to not break compatibilty with older versions
            crewmateRolesCountMin = CustomOption.Create(300, cs(new Color(0, 1, 217f / 255f, 1f), "������� ������ �����"), "option", 0f, 0f, 15f, 1f, null, true);
            crewmateRolesCountMax = CustomOption.Create(301, cs(new Color(0, 1, 217f / 255f, 1f), "�������� ������ ����� "), "option", 0f, 0f, 15f, 1f);
            crewmateRolesMax = CustomOption.Create(9020, cs(new Color(0, 1, 217f / 255f, 1f), "�������������� ������ ����"), "option", false);
            neutralRolesCountMin = CustomOption.Create(302, cs(new Color(0, 1, 217f / 255f, 1f), "������� ����������� �����"), "option", 0f, 0f, 15f, 1f);
            neutralRolesCountMax = CustomOption.Create(303, cs(new Color(0, 1, 217f / 255f, 1f), "�������� ����������� �����"), "option", 0f, 0f, 15f, 1f);
            impostorRolesCountMin = CustomOption.Create(304, cs(new Color(0, 1, 217f / 255f, 1f), "������� ����� ����������"), "option", 0f, 0f, 3f, 1f);
            impostorRolesCountMax = CustomOption.Create(305, cs(new Color(0, 1, 217f / 255f, 1f), "�������� ����� ����������"), "option", 0f, 0f, 3f, 1f);

            mafiaSpawnRate = CustomOption.Create(10, cs(Janitor.color, "�����"), "impostor", rates, null, true);
            janitorCooldown = CustomOption.Create(11, "�� ������� �����", "impostor", 30f, 10f, 60f, 2.5f, mafiaSpawnRate);

            morphlingSpawnRate = CustomOption.Create(20, cs(Morphling.color, "���������"), "impostor", rates, null, true);
            morphlingCooldown = CustomOption.Create(21, "�� ����������", "impostor", 30f, 10f, 60f, 2.5f, morphlingSpawnRate);
            morphlingDuration = CustomOption.Create(22, "������������ ����������", "impostor", 10f, 1f, 20f, 0.5f, morphlingSpawnRate);

            camouflagerSpawnRate = CustomOption.Create(30, cs(Camouflager.color, "�����������"), "impostor", rates, null, true);
            camouflagerCooldown = CustomOption.Create(31, "�� ���������", "impostor", 30f, 10f, 60f, 2.5f, camouflagerSpawnRate);
            camouflagerDuration = CustomOption.Create(32, "������������ ���������", "impostor", 10f, 1f, 20f, 0.5f, camouflagerSpawnRate);

            vampireSpawnRate = CustomOption.Create(40, cs(Vampire.color, "������"), "impostor", rates, null, true);
            vampireKillDelay = CustomOption.Create(41, "�� �� �������� � �������", "impostor", 10f, 1f, 20f, 1f, vampireSpawnRate);
            vampireCooldown = CustomOption.Create(42, "�� ����� �������", "impostor", 30f, 10f, 60f, 2.5f, vampireSpawnRate);
            vampireCanKillNearGarlics = CustomOption.Create(43, "������ ����� �������\n����� � ��������", "impostor", true, vampireSpawnRate);

            eraserSpawnRate = CustomOption.Create(230, cs(Eraser.color, "���������"), "impostor", rates, null, true);
            eraserCooldown = CustomOption.Create(231, "�� ��������", "impostor", 30f, 10f, 120f, 5f, eraserSpawnRate);
            eraserCanEraseAnyone = CustomOption.Create(232, "��������� ����� ������� ������\n", "impostor", false, eraserSpawnRate);

            tricksterSpawnRate = CustomOption.Create(250, cs(Trickster.color, "��������"), "impostor", rates, null, true);
            tricksterPlaceBoxCooldown = CustomOption.Create(251, "�� ������� ���������", "impostor", 10f, 2.5f, 30f, 2.5f, tricksterSpawnRate);
            tricksterPlaceBoxCount = CustomOption.Create(506, "���������� ������� ���������", "impostor", 3f, 2f, 7f, 1f, tricksterSpawnRate);
            tricksterLightsOutCooldown = CustomOption.Create(252, "�� ���������� ����� ���������\n", "impostor", 30f, 10f, 60f, 5f, tricksterSpawnRate);
            tricksterLightsOutDuration = CustomOption.Create(253, "������������ ���������� ����� ���������\n", "impostor", 15f, 5f, 60f, 2.5f, tricksterSpawnRate);

            cleanerSpawnRate = CustomOption.Create(260, cs(Cleaner.color, "�������"), "impostor", rates, null, true);
            cleanerCooldown = CustomOption.Create(261, "�� �������", "impostor", 30f, 10f, 60f, 2.5f, cleanerSpawnRate);

            warlockSpawnRate = CustomOption.Create(270, cs(Cleaner.color, "������"), "impostor", rates, null, true);
            warlockCooldown = CustomOption.Create(271, "�� �������", "impostor", 30f, 10f, 60f, 2.5f, warlockSpawnRate);
            warlockRootTime = CustomOption.Create(272, "����� �����������", "impostor", 5f, 0f, 15f, 1f, warlockSpawnRate);

            bountyHunterSpawnRate = CustomOption.Create(320, cs(BountyHunter.color, "������� �� ��������"), "impostor", rates, null, true);
            bountyHunterBountyDuration = CustomOption.Create(321, "�� �� �������� �����\n���������", "impostor", 60f, 10f, 180f, 10f, bountyHunterSpawnRate);
            bountyHunterReducedCooldown = CustomOption.Create(322, "�� ����� \n�������� ����", "impostor", 2.5f, 0f, 30f, 2.5f, bountyHunterSpawnRate);
            bountyHunterPunishmentTime = CustomOption.Create(323, "�������������� ��\n����� �������� ������", "impostor", 20f, 0f, 60f, 2.5f, bountyHunterSpawnRate);
            bountyHunterShowArrow = CustomOption.Create(324, "���������� ������� �� ���� \n", "impostor", true, bountyHunterSpawnRate);
            bountyHunterArrowUpdateIntervall = CustomOption.Create(325, "�������� ����������� �������", "impostor", 5f, 0f, 60f, 2.5f, bountyHunterShowArrow);

            witchSpawnRate = CustomOption.Create(370, cs(Witch.color, "������"), "impostor", rates, null, true);
            witchCooldown = CustomOption.Create(371, "�������� ����������\n����� ��", "impostor", 30f, 10f, 120f, 5f, witchSpawnRate);
            witchAdditionalCooldown = CustomOption.Create(372, "�������������� �� ������", "impostor", 10f, 0f, 60f, 5f, witchSpawnRate);
            witchCanSpellAnyone = CustomOption.Create(373, "������ ����� ��������� �� ����", "impostor", false, witchSpawnRate);
            witchSpellCastingDuration = CustomOption.Create(374, "������������ ����������", "impostor", 1f, 0f, 10f, 1f, witchSpawnRate);
            witchTriggerBothCooldowns = CustomOption.Create(375, "����������� ��� ��", "impostor", true, witchSpawnRate);
            witchVoteSavesTargets = CustomOption.Create(376, "����������� ������ �������\n���� �������������", "impostor", true, witchSpawnRate);

            phaserSpawnRate = CustomOption.Create(9000, cs(Cleaner.color, "���� ������"), "impostor", rates, null, true);
            phaserMarkCooldown = CustomOption.Create(9001, "�� �����", "impostor", 20f, 10f, 60f, 2.5f, phaserSpawnRate);
            phaserPhaseCooldown = CustomOption.Create(9002, "�� �������� � �����������������", "impostor", 10f, 10f, 60f, 2.5f, phaserSpawnRate);

            miniSpawnRate = CustomOption.Create(180, cs(Mini.color, "������"), "other", rates, null, true);
            miniGrowingUpDuration = CustomOption.Create(181, "����� ���������� ������� ������", "other", 400f, 100f, 1500f, 100f, miniSpawnRate);
            miniEvilGuessable = CustomOption.Create(319, "����� ������ ����� ��������", "other", true, miniSpawnRate);

            loversSpawnRate = CustomOption.Create(50, cs(Lovers.color, "���������"), "other", rates, null, true);
            loversImpLoverRate = CustomOption.Create(51, "���� ����,���\n�������� ��������", "other", rates, loversSpawnRate);
            loversBothDie = CustomOption.Create(52, "��� ��������� �������", "other", true, loversSpawnRate);
            loversCanHaveAnotherRole = CustomOption.Create(53, "��������� ����� �����\n������ ����", "other", true, loversSpawnRate);
            loversEnableChat = CustomOption.Create(54, "�������� ��� ����������", "other", true, loversSpawnRate);
            loversAliveCount = CustomOption.Create(312, "����� ����� ��� ������ ����������", "other", 3f, 2f, 3f, 1f, loversSpawnRate);

            guesserSpawnRate = CustomOption.Create(310, cs(Guesser.color, "�������"), "other", rates, null, true);
            guesserIsImpGuesserRate = CustomOption.Create(311, "���� ����,��� �������\n��������", "other", rates, guesserSpawnRate);
            guesserNumberOfShots = CustomOption.Create(312, "���������� ��������� ��������", "other", 2f, 1f, 15f, 1f, guesserSpawnRate);
            guesserHasMultipleShotsPerMeeting = CustomOption.Create(313, "������� ����� ��������\n��������� ��� �� �����������", "other", false, guesserSpawnRate);
            guesserShowInfoInGhostChat = CustomOption.Create(314, "�������� �����\n� ���� ���������", "other", true, guesserSpawnRate);
            guesserKillsThroughShield  = CustomOption.Create(315, "�������� ����������\n��� ������", "other", true, guesserSpawnRate);
            guesserEvilCanKillSpy  = CustomOption.Create(316, "������ ������� \n����� ������� ������", "other", true, guesserSpawnRate);
            guesserSpawnBothRate = CustomOption.Create(317, "���� ����,��� ����� ��� ��������", "other", rates, guesserSpawnRate);
            guesserCantGuessSnitchIfTaksDone = CustomOption.Create(318, "������� �� ����� ������� �������\n����� ���������� �������", "other", true, guesserSpawnRate);

            jesterSpawnRate = CustomOption.Create(60, cs(Jester.color, "���"), "neutral", rates, null, true);
            jesterCanCallEmergency = CustomOption.Create(61, "��� ����� ������ ������\n", "neutral", true, jesterSpawnRate);
            jesterHasImpostorVision = CustomOption.Create(62, "��� ����� ������ ���������", "neutral", false, jesterSpawnRate);
            jesterCanBeLawyerClient = CustomOption.Create(8000, "��� ����� ���� ��������\n��������", "neutral", false, jesterSpawnRate);

            arsonistSpawnRate = CustomOption.Create(290, cs(Arsonist.color, "�����������"), "neutral", rates, null, true);
            arsonistCooldown = CustomOption.Create(291, "�� ������", "neutral", 12.5f, 2.5f, 60f, 2.5f, arsonistSpawnRate);
            arsonistDuration = CustomOption.Create(292, "������������ ����������", "neutral", 3f, 1f, 10f, 1f, arsonistSpawnRate);

            jackalSpawnRate = CustomOption.Create(220, cs(Jackal.color, "�����"), "neutral", rates, null, true);
            jackalKillCooldown = CustomOption.Create(221, "����� � ��������\n�� ��������", "neutral", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
            jackalCreateSidekickCooldown = CustomOption.Create(222, "����� ��������\n�� ���������", "neutral", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
            jackalCanUseVents = CustomOption.Create(223, "����� ����� ������������ ����������", "neutral", true, jackalSpawnRate);
            jackalCanCreateSidekick = CustomOption.Create(224, "����� ����� ������ ���������", "neutral", false, jackalSpawnRate);
            sidekickPromotesToJackal = CustomOption.Create(225, "�������� ���������� \n�� ������ ����� ������ ������", "neutral", false, jackalSpawnRate);
            sidekickCanKill = CustomOption.Create(226, "�������� ����� �������", "neutral", false, jackalSpawnRate);
            sidekickCanUseVents = CustomOption.Create(227, "�������� ����� ������������ ����������", "neutral", true, jackalSpawnRate);
            jackalPromotedFromSidekickCanCreateSidekick = CustomOption.Create(228, "�������� ���������� �� ������\n����� ������� ���������", "neutral", true, jackalSpawnRate);
            jackalCanCreateSidekickFromImpostor = CustomOption.Create(229, "����� ����� ������\n���������� �� ���������", "neutral", true, jackalSpawnRate);
            jackalAndSidekickHaveImpostorVision = CustomOption.Create(430, "����� � ��������\n����� ������ ���������", "neutral", false, jackalSpawnRate);

            vultureSpawnRate = CustomOption.Create(340, cs(Vulture.color, "��������� ������"), "neutral", rates, null, true);
            vultureCooldown = CustomOption.Create(341, "�� �������� �����", "neutral", 15f, 10f, 60f, 2.5f, vultureSpawnRate);
            vultureNumberToWin = CustomOption.Create(342, "���������� ������\n������,����� ��������", "neutral", 4f, 1f, 10f, 1f, vultureSpawnRate);
            vultureCanUseVents = CustomOption.Create(343, "��������� ������ ����� ������������ ����������", "neutral", true, vultureSpawnRate);
            vultureShowArrows = CustomOption.Create(344, "���������� �������\n�� �����", "neutral", true, vultureSpawnRate);

            lawyerSpawnRate = CustomOption.Create(350, cs(Lawyer.color, "�������"), "neutral", rates, null, true);
            lawyerTargetKnows = CustomOption.Create(351, "������� ����� ������ �������", "neutral", true, lawyerSpawnRate);
            lawyerWinsAfterMeetings = CustomOption.Create(352, "������� ��������� ����� �����������", "neutral", false, lawyerSpawnRate);
            lawyerNeededMeetings = CustomOption.Create(353, "������� ��������� � ������������ ��� ������", "neutral", 5f, 1f, 15f, 1f, lawyerWinsAfterMeetings);
            lawyerVision = CustomOption.Create(354, "������ ��������", "neutral", 1f, 0.25f, 3f, 0.25f, lawyerSpawnRate);
            lawyerKnowsRole = CustomOption.Create(355, "������� ����� ���� �������", "neutral", false, lawyerSpawnRate);
            pursuerCooldown = CustomOption.Create(356, "�� ������ ��������������", "neutral", 30f, 5f, 60f, 2.5f, lawyerSpawnRate);
            pursuerBlanksNumber = CustomOption.Create(357, "���������� ������� ��������������", "neutral", 5f, 1f, 20f, 1f, lawyerSpawnRate);

            shifterSpawnRate = CustomOption.Create(70, cs(Shifter.color, "������"), "crewmate", rates, null, true);
            shifterShiftsModifiers = CustomOption.Create(71, "������ ������ �����������", "crewmate", false, shifterSpawnRate);
            shifterShiftsSelf = CustomOption.Create(9030, "������ ������ ����", "crewmate", false, shifterSpawnRate);
            shifterDiesBeforeMeeting = CustomOption.Create(9031, "������ ������� �� ��������", "crewmate", false, shifterSpawnRate);

            mayorSpawnRate = CustomOption.Create(80, cs(Mayor.color, "���"), "crewmate", rates, null, true);
            mayorShowVotes = CustomOption.Create(9010, "���������� ������ ����", "crewmate", false, mayorSpawnRate);

            engineerSpawnRate = CustomOption.Create(90, cs(Engineer.color, "�������"), "crewmate", rates, null, true);
            engineerNumberOfFixes = CustomOption.Create(91, "����� ���������� ���������", "crewmate", 1f, 1f, 3f, 1f, engineerSpawnRate);
            engineerHighlightForImpostors = CustomOption.Create(92, "��������� ����� ������������ ����������", "crewmate", true, engineerSpawnRate);
            engineerHighlightForTeamJackal = CustomOption.Create(93, "����� � ��������\n����� ������������ ���������� ", "crewmate", true, engineerSpawnRate);

            sheriffSpawnRate = CustomOption.Create(100, cs(Sheriff.color, "�����"), "crewmate", rates, null, true);
            sheriffCooldown = CustomOption.Create(101, "�� ������", "crewmate", 30f, 10f, 60f, 2.5f, sheriffSpawnRate);
            sheriffCanKillNeutrals = CustomOption.Create(102, "����� ����� ������� ���������", "crewmate", false, sheriffSpawnRate);
            deputySpawnRate = CustomOption.Create(103, "� ������ ���� �����������", "crewmate", rates, sheriffSpawnRate);
            deputyNumberOfHandcuffs = CustomOption.Create(104, "���������� ���������� � �����������", "crewmate", 3f, 1f, 10f, 1f, deputySpawnRate);
            deputyHandcuffCooldown = CustomOption.Create(105, "�� ����������", "crewmate", 30f, 10f, 60f, 2.5f, deputySpawnRate);
            deputyHandcuffDuration = CustomOption.Create(106, "������������ ����������", "crewmate", 15f, 5f, 60f, 2.5f, deputySpawnRate);
            deputyKnowsSheriff = CustomOption.Create(107, "����� � ����������� ����� ���� ����� ", "crewmate", true, deputySpawnRate);
            deputyGetsPromoted = CustomOption.Create(108, "����������� ���������� �� ������", "crewmate", new string[] { "����", "��� (����������)", "��� (����� ��������)" }, deputySpawnRate);
            deputyKeepsHandcuffs = CustomOption.Create(109, "� ����������� �� ��� ���� ���������, ����� �� �������", "crewmate", true, deputyGetsPromoted);

            lighterSpawnRate = CustomOption.Create(110, cs(Lighter.color, "����������"), "crewmate", rates, null, true);
            lighterModeLightsOnVision = CustomOption.Create(111, "����� ������ �����������\n����� ���� �������", "crewmate", 2f, 0.25f, 5f, 0.25f, lighterSpawnRate);
            lighterModeLightsOffVision = CustomOption.Create(112, "����� ������ �����������\n����� ���� ��������", "crewmate", 0.75f, 0.25f, 5f, 0.25f, lighterSpawnRate);
            lighterCooldown = CustomOption.Create(113, "�� �����", "crewmate", 30f, 5f, 120f, 5f, lighterSpawnRate);
            lighterDuration = CustomOption.Create(114, "������������ �����", "crewmate", 5f, 2.5f, 60f, 2.5f, lighterSpawnRate);

            detectiveSpawnRate = CustomOption.Create(120, cs(Detective.color, "��������"), "crewmate", rates, null, true);
            detectiveAnonymousFootprints = CustomOption.Create(121, "��������� �����", "crewmate", false, detectiveSpawnRate);
            detectiveFootprintIntervall = CustomOption.Create(122, "�������� ������", "crewmate", 0.5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
            detectiveFootprintDuration = CustomOption.Create(123, "������������ ������", "crewmate", 5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
            detectiveReportNameDuration = CustomOption.Create(124, "����� ����� �������� �������� � �����\n������ ���", "crewmate", 0, 0, 60, 2.5f, detectiveSpawnRate);
            detectiveReportColorDuration = CustomOption.Create(125, "����� ����� �������� �������� � �����\n������ ��� ����� ������", "crewmate", 20, 0, 120, 2.5f, detectiveSpawnRate);

            timeMasterSpawnRate = CustomOption.Create(130, cs(TimeMaster.color, "������ �������"), "crewmate", rates, null, true);
            timeMasterCooldown = CustomOption.Create(131, "�� ������ �������", "crewmate", 30f, 10f, 120f, 2.5f, timeMasterSpawnRate);
            timeMasterRewindTime = CustomOption.Create(132, "����� ������� ����������", "crewmate", 3f, 1f, 10f, 1f, timeMasterSpawnRate);
            timeMasterShieldDuration = CustomOption.Create(133, "������������ ���� �������", "crewmate", 3f, 1f, 20f, 1f, timeMasterSpawnRate);

            medicSpawnRate = CustomOption.Create(140, cs(Medic.color, "�����"), "crewmate", rates, null, true);
            medicShowShielded = CustomOption.Create(143, "���������� ����������� ������", "crewmate", new string[] { "����", "����������� ������ + ������", "������" }, medicSpawnRate);
            medicShowAttemptToShielded = CustomOption.Create(144, "���������� �����\n����� ������� ��������", "crewmate", false, medicSpawnRate);
            medicSetShieldAfterMeeting = CustomOption.Create(145, "��� ����� ����������\n����� ���������� ��������", "crewmate", false, medicSpawnRate);
            medicShowAttemptToMedic = CustomOption.Create(146, "����� ����� ������� ��������\n����������� ������", "crewmate", false, medicSpawnRate);

            swapperSpawnRate = CustomOption.Create(150, cs(Swapper.color, "�������"), "crewmate", rates, null, true);
            swapperCanCallEmergency = CustomOption.Create(151, "������� ����� �������\n���������� ��������", "crewmate", false, swapperSpawnRate);
            swapperCanOnlySwapOthers = CustomOption.Create(152, "������� ����� ������\n������ ������", "crewmate", false, swapperSpawnRate);

            seerSpawnRate = CustomOption.Create(160, cs(Seer.color, "�����������"), "crewmate", rates, null, true);
            seerMode = CustomOption.Create(161, "����� ������������", "crewmate", new string[] { "����������\n������� ��� ������ + ����", "����������\n������� ��� ������", "����������\n����" }, seerSpawnRate);
            seerLimitSoulDuration = CustomOption.Create(163, "����� ��������������", "crewmate", false, seerSpawnRate);
            seerSoulDuration = CustomOption.Create(162, "������������ ��������������", "crewmate", 15f, 0f, 120f, 5f, seerLimitSoulDuration);

            hackerSpawnRate = CustomOption.Create(170, cs(Hacker.color, "�����"), "crewmate", rates, null, true);
            hackerCooldown = CustomOption.Create(171, "�� ������", "crewmate", 30f, 5f, 60f, 5f, hackerSpawnRate);
            hackerHackeringDuration = CustomOption.Create(172, "������������ ������", "crewmate", 10f, 2.5f, 60f, 2.5f, hackerSpawnRate);
            hackerOnlyColorType = CustomOption.Create(173, "����� ������\n��� �����", "crewmate", false, hackerSpawnRate);
            hackerToolsNumber = CustomOption.Create(174, "������������ ���������� ������� ���������", "crewmate", 5f, 1f, 30f, 1f, hackerSpawnRate);
            hackerRechargeTasksNumber = CustomOption.Create(175, "���������� �������\n����������� ��� �����������", "crewmate", 2f, 1f, 5f, 1f, hackerSpawnRate);
            hackerNoMove = CustomOption.Create(176, "�� ����� ��������� �� �����\n��������� ���������� �������", "crewmate", true, hackerSpawnRate);

            trackerSpawnRate = CustomOption.Create(200, cs(Tracker.color, "�������������"), "crewmate", rates, null, true);
            trackerUpdateIntervall = CustomOption.Create(201, "�������� ���������� ������������", "crewmate", 5f, 0f, 30f, 1f, trackerSpawnRate);
            trackerResetTargetAfterMeeting = CustomOption.Create(202, "���� ����������\n����� ��������", "crewmate", false, trackerSpawnRate);
            trackerCanTrackCorpses = CustomOption.Create(203, "������������� ����� ����������� �����", "crewmate", true, trackerSpawnRate);
            trackerCorpsesTrackingCooldown = CustomOption.Create(204, "�� ������������ ������", "crewmate", 30f, 5f, 120f, 5f, trackerCanTrackCorpses);
            trackerCorpsesTrackingDuration = CustomOption.Create(205, "������������ ������������ ������", "crewmate", 5f, 2.5f, 30f, 2.5f, trackerCanTrackCorpses);

            snitchSpawnRate = CustomOption.Create(210, cs(Snitch.color, "������"), "crewmate", rates, null, true);
            snitchLeftTasksForReveal = CustomOption.Create(211, "���������� ������� �����\n������ ����� �������", "crewmate", 1f, 0f, 5f, 1f, snitchSpawnRate);
            snitchIncludeTeamJackal = CustomOption.Create(212, "������� ������� ������", "crewmate", false, snitchSpawnRate);
            snitchTeamJackalUseDifferentArrowColor = CustomOption.Create(213, "������������ ������ ���� �������\n��� ������� ������", "crewmate", true, snitchIncludeTeamJackal);

            spySpawnRate = CustomOption.Create(240, cs(Spy.color, "�����"), "crewmate", rates, null, true);
            spyCanDieToSheriff = CustomOption.Create(241, "����� ����� ����� ������", "crewmate", false, spySpawnRate);
            spyImpostorsCanKillAnyone = CustomOption.Create(242, "��������� ����� ������� ����\n���� ���� �����", "crewmate", true, spySpawnRate);
            spyCanEnterVents = CustomOption.Create(243, "����� ����� ������� � ����������", "crewmate", false, spySpawnRate);
            spyHasImpostorVision = CustomOption.Create(244, "� ������ ������ ���������", "crewmate", false, spySpawnRate);

            securityGuardSpawnRate = CustomOption.Create(280, cs(SecurityGuard.color, "��������"), "crewmate", rates, null, true);
            securityGuardCooldown = CustomOption.Create(281, "�� ���������", "crewmate", 30f, 10f, 60f, 2.5f, securityGuardSpawnRate);
            securityGuardTotalScrews = CustomOption.Create(282, "���������� �������������", "crewmate", 7f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardCamPrice = CustomOption.Create(283, "��������� ������������� ������", "crewmate", 2f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardVentPrice = CustomOption.Create(284, "��������� ������������� ����������", "crewmate", 1f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardCamDuration = CustomOption.Create(285, "������������ ���������", "crewmate", 10f, 2.5f, 60f, 2.5f, securityGuardSpawnRate);
            securityGuardCamMaxCharges = CustomOption.Create(286, "������������ ���������� �������", "crewmate", 5f, 1f, 30f, 1f, securityGuardSpawnRate);
            securityGuardCamRechargeTasksNumber = CustomOption.Create(287, "���������� ������� �����������\n��� �����������", "crewmate", 3f, 1f, 10f, 1f, securityGuardSpawnRate);
            securityGuardNoMove = CustomOption.Create(288, "�� ����� ��������� �� ����� ������������� ������", "crewmate", true, securityGuardSpawnRate);

            baitSpawnRate = CustomOption.Create(330, cs(Bait.color, "��������"), "crewmate", rates, null, true);
            baitHighlightAllVents = CustomOption.Create(331, "������������ ����������\n������� ������", "crewmate", false, baitSpawnRate);
            baitReportDelay = CustomOption.Create(332, "����� ������� ����� ������� ��������", "crewmate", 0f, 0f, 10f, 1f, baitSpawnRate);
            baitShowKillFlash = CustomOption.Create(333, "������������� ������ ��������", "crewmate", true, baitSpawnRate);

            mediumSpawnRate = CustomOption.Create(360, cs(Medium.color, "������"), "crewmate", rates, null, true);
            mediumCooldown = CustomOption.Create(361, "�� �������� �������", "crewmate", 30f, 5f, 120f, 5f, mediumSpawnRate);
            mediumDuration = CustomOption.Create(362, "������������ �����������", "crewmate", 3f, 0f, 15f, 1f, mediumSpawnRate);
            mediumOneTimeUse = CustomOption.Create(363, "������ ���� �����\n �������� ������ ���� ���", "crewmate", false, mediumSpawnRate);

            jumperSpawnRate = CustomOption.Create(9050, cs(Jumper.color, "������"), "crewmate", rates, null, true);
            jumperJumpTime = CustomOption.Create(9051, "�� ������", "crewmate", 30, 0, 60, 5, jumperSpawnRate);
            jumperChargesOnPlace = CustomOption.Create(9052, "������� �� �����", "crewmate", 1, 0, 10, 1, jumperSpawnRate);
            jumperChargesGainOnMeeting = CustomOption.Create(9053, "���������� ������� ������� ������ ����� ��������", "crewmate", 2, 0, 10, 1, jumperSpawnRate);
            jumperMaxCharges = CustomOption.Create(9054, "�������� �������", "crewmate", 3, 0, 10, 1, jumperSpawnRate);

            // Other options
            maxNumberOfMeetings = CustomOption.Create(3, cs(new Color(0, 1, 217f / 255f, 1f), "���������� ��������\n(��������� �������� ����)"), "option", 10, 0, 15, 1, null, true);
            blockSkippingInEmergencyMeetings = CustomOption.Create(4, cs(new Color(0, 1, 217f / 255f, 1f), "������ ����������\n�� ���������� ��������"), "option", false);
            noVoteIsSelfVote = CustomOption.Create(5, cs(new Color(0, 1, 217f / 255f, 1f), "�� ������� ����� ���� ������������ � ����"), "option", false, blockSkippingInEmergencyMeetings);
            hidePlayerNames = CustomOption.Create(6, cs(new Color(0, 1, 217f / 255f, 1f), "�������� ����� �������"), "option", false);
            allowParallelMedBayScans = CustomOption.Create(7, cs(new Color(0, 1, 217f / 255f, 1f), "������������ ������������"), "option", false);

            //LVK. Setting if the target of a button should be shown
            showButtonTarget = CustomOption.Create(9040, cs(new Color(0, 1, 217f / 255f, 1f), "Show Button Target"), "option", true);
            //LVK. Random Spawn on round start
            randomGameStartPosition = CustomOption.Create(9041, cs(new Color(0, 1, 217f / 255f, 1f), "��������� ����� ���������"), "option", true);
            //LVK. Cooldown on round start setting
            setRoundStartCooldown = CustomOption.Create(9042, cs(new Color(0, 1, 217f / 255f, 1f), "�������� ���������"), "option", 30f, 10f, 60f, 2.5f, null, true);
            //LVK. First Kill Shield on or off
            firstKillShield = CustomOption.Create(9043, cs(new Color(0, 1, 217f / 255f, 1f), "�������� ������ �������� ����� ������\n� ������� ����"), "option", true);
            //Monschtalein. toggle lobby mode
            toggleLobbyMode = CustomOption.Create(7000, cs(new Color(0, 1, 217f / 255f, 1f), "������������ �� ������� �������"), "option", new string[] { "No", "Yes" }, null, false);

            dynamicMap = CustomOption.Create(8, cs(new Color(0, 1, 217f / 255f, 1f), "������ �� ��������� �����"), "map", false, null, true);
            dynamicMapEnableSkeld = CustomOption.Create(501, cs(new Color(0, 1, 217f / 255f, 1f), "�������� ����������� ��������� The Skeld"), "map", true, dynamicMap, false);
            dynamicMapEnableMira = CustomOption.Create(502, cs(new Color(0, 1, 217f / 255f, 1f), "�������� ����������� ��������� MiraHQ"), "map", true, dynamicMap, false);
            dynamicMapEnablePolus = CustomOption.Create(503, cs(new Color(0, 1, 217f / 255f, 1f), "�������� ����������� ��������� ������"), "map", true, dynamicMap, false);
            dynamicMapEnableAirShip = CustomOption.Create(504, cs(new Color(0, 1, 217f / 255f, 1f), "�������� ����������� ��������� Airship"), "map", true, dynamicMap, false);
            //dynamicMapEnableDleks = CustomOption.Create(505, cs(new Color(0, 1, 217f / 255f, 1f), "�������� ����������� ��������� ������������ The Skeld"), "map", false, dynamicMap, false);

            blockedRolePairings.Add((byte)RoleId.Vampire, new[] { (byte)RoleId.Warlock });
            blockedRolePairings.Add((byte)RoleId.Warlock, new[] { (byte)RoleId.Vampire });

            blockedRolePairings.Add((byte)RoleId.Spy, new[] { (byte)RoleId.Mini });
            blockedRolePairings.Add((byte)RoleId.Mini, new[] { (byte)RoleId.Spy });

            blockedRolePairings.Add((byte)RoleId.Vulture, new[] { (byte)RoleId.Cleaner });
            blockedRolePairings.Add((byte)RoleId.Cleaner, new[] { (byte)RoleId.Vulture });

            blockedRolePairings.Add((byte)RoleId.Phaser, new[] { (byte)RoleId.Camouflager });
            blockedRolePairings.Add((byte)RoleId.Camouflager, new[] { (byte)RoleId.Phaser });

        }
    }
}

