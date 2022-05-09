using HarmonyLib;
using System.Linq;
using System;
using System.Collections.Generic;
using static TheEpicRoles.TheEpicRoles;
using UnityEngine;

namespace TheEpicRoles {
    class RoleInfo {
        public Color color;
        public string name;
        public string introDescription;
        public string shortDescription;
        public RoleId roleId;
        public bool isNeutral;

        RoleInfo(string name, Color color, string introDescription, string shortDescription, RoleId roleId, bool isNeutral = false) {
            this.color = color;
            this.name = name;
            this.introDescription = introDescription;
            this.shortDescription = shortDescription;
            this.roleId = roleId;
            this.isNeutral = isNeutral;
        }

        public static RoleInfo jester = new RoleInfo("Шут", Jester.color, "Позволь себя выкинуть", "Позволь себя выкинуть", RoleId.Jester, true);
        public static RoleInfo mayor = new RoleInfo("Мэр", Mayor.color, "Твои голоса теперь двойные!", "Твои голоса теперь двойные!", RoleId.Mayor);
        public static RoleInfo engineer = new RoleInfo("Инженер",  Engineer.color, "Теперь ты можешь пользоваться люками", "Чини саботаж одной кнопкой!", RoleId.Engineer);
        public static RoleInfo sheriff = new RoleInfo("Шериф", Sheriff.color, "Убей <color=#FF1919FF>Импостера</color>", "Убей импостеров", RoleId.Sheriff);
        public static RoleInfo deputy = new RoleInfo("Заместитель", Sheriff.color, "Помести под стражу <color=#FF1919FF>Импостера</color>", "Надень наручники на импостера", RoleId.Deputy);
        public static RoleInfo lighter = new RoleInfo("Светящийся", Lighter.color, "Теперь ты видишь всё", "Теперь ты видишь всё", RoleId.Lighter);
        public static RoleInfo godfather = new RoleInfo("Крёстный Отец", Godfather.color, "Убей всех мирных", "Убей всех мирных", RoleId.Godfather);
        public static RoleInfo mafioso = new RoleInfo("Мафиози", Mafioso.color, "Работай вместе с <color=#FF1919FF>Мафией</color> чтобы убить всех", "Убей всех мирных", RoleId.Mafioso);
        public static RoleInfo janitor = new RoleInfo("Уборщик", Janitor.color, "Работай вместе с <color=#FF1919FF>Мафией</color> и скрывай все трупы", "Скрывай трупы", RoleId.Janitor);
        public static RoleInfo morphling = new RoleInfo("Оборотень", Morphling.color, "Перевоплотись в другого и делай убийства", "Измени свой облик", RoleId.Morphling);
        public static RoleInfo camouflager = new RoleInfo("Маскировщик", Camouflager.color, "Замаскируйся и убей мирных", "Спрячься среди других", RoleId.Camouflager);
        public static RoleInfo vampire = new RoleInfo("Вампир", Vampire.color, "Убей мирных своими укусами", "Укуси своих врагов", RoleId.Vampire);
        public static RoleInfo eraser = new RoleInfo("Стиратель", Eraser.color, "Убей мирных,стирая их роли", "Сотри роли своих врагов", RoleId.Eraser);
        public static RoleInfo trickster = new RoleInfo("Трикстер", Trickster.color, "Поставь свои коробки,чтобы перемещаться между ними,как по вентиляциям", "Удиви своих врагов", RoleId.Trickster);
        public static RoleInfo cleaner = new RoleInfo("Уборщик", Cleaner.color, "Убей всех,убирая трупы", "Убери трупы мирных", RoleId.Cleaner);
        public static RoleInfo warlock = new RoleInfo("Колдун", Warlock.color, "Прокляни мирных,чтобы убить их", "Прокляни и убей всех", RoleId.Warlock);
        public static RoleInfo bountyHunter = new RoleInfo("Охотник за головами", BountyHunter.color, "Убей свою цель,чтобы убивать без заддержки", "Убей свою цель", RoleId.BountyHunter);
        public static RoleInfo detective = new RoleInfo("Детектив", Detective.color, "Найди <color=#FF1919FF>Импостеров</color> по их следам", "Увидь чужие следы", RoleId.Detective);
        public static RoleInfo timeMaster = new RoleInfo("Мастер времени", TimeMaster.color, "Спаси себя с помощью щита времени", "Используй свой щит времени", RoleId.TimeMaster);
        public static RoleInfo medic = new RoleInfo("Медик", Medic.color, "Защити других с помощью щита", "Защити других игроков", RoleId.Medic);
        public static RoleInfo shifter = new RoleInfo("Шифтер", Shifter.color, "Обменяйся ролью с человеком", "Обменяй свою роль", RoleId.Shifter);
        public static RoleInfo swapper = new RoleInfo("Сваппер", Swapper.color, "Меняй голоса чтобы выкинуть <color=#FF1919FF>Импостера</color>", "Меняй голоса", RoleId.Swapper);
        public static RoleInfo seer = new RoleInfo("Ясновидящий", Seer.color, "Ты видишь,когда умирают люди", "Ты видишь,когда умирают люди", RoleId.Seer);
        public static RoleInfo hacker = new RoleInfo("Хакер", Hacker.color, "Взломай систему чтобы найти <color=#FF1919FF>Импостера</color>", "Взломай,чтобы найти импостеров", RoleId.Hacker);
        public static RoleInfo niceMini = new RoleInfo("Добрый ребёнок", Mini.color, "Никто не может навредить тебе", "Никто тебе не навредит", RoleId.Mini);
        public static RoleInfo evilMini = new RoleInfo("Злой ребёнок", Palette.ImpostorRed, "Никто не может навредить тебе,пока не вырастешь", "Никто тебе не навредит", RoleId.Mini);
        public static RoleInfo tracker = new RoleInfo("Отслеживатель", Tracker.color, "Устрой слежку за <color=#FF1919FF>Импостером</color> чтобы найти его", "Отследи Импостера", RoleId.Tracker);
        public static RoleInfo snitch = new RoleInfo("Стукач", Snitch.color, "Заверши задания,чтобы найти <color=#FF1919FF>Импостеров</color>", "Заверши задания", RoleId.Snitch);
        public static RoleInfo jackal = new RoleInfo("Шакал", Jackal.color, "Убей <color=#FF1919FF>Всех</color> чтобы победить", "Убей всех", RoleId.Jackal, true);
        public static RoleInfo sidekick = new RoleInfo("Сообщник", Sidekick.color, "Помоги шакалу победить", "Помоги шакалу победить", RoleId.Sidekick, true);
        public static RoleInfo spy = new RoleInfo("Шпион", Spy.color, "Запутай <color=#FF1919FF>Импостеров</color>", "Запутай импостеров", RoleId.Spy);
        public static RoleInfo securityGuard = new RoleInfo("Охранник", SecurityGuard.color, "Запечатывай вентиляции и установливай камеры", "Запечатай вентиляцию и установи камеры", RoleId.SecurityGuard);
        public static RoleInfo arsonist = new RoleInfo("Поджигатель", Arsonist.color, "Подожги всех,чтобы победить", "Подожги всех", RoleId.Arsonist, true);
        public static RoleInfo goodGuesser = new RoleInfo("Добрый снайпер", Guesser.color, "Угадай плохую роль,чтобы убить его", "Догадайся и стреляй", RoleId.NiceGuesser);
        public static RoleInfo badGuesser = new RoleInfo("Злой снайпер", Palette.ImpostorRed, "Угадай роль,чтобы убить его", "Догадайся и выстрели", RoleId.EvilGuesser);
        public static RoleInfo bait = new RoleInfo("Приманка", Bait.color, "Тот кто убьёт тебя,мгновенно зарепортит", "Дай убить себя импостеру", RoleId.Bait);
        public static RoleInfo vulture = new RoleInfo("Поедатель трупов", Vulture.color, "Сьешь трупы,чтобы победить", "Ешь трупы", RoleId.Vulture, true);
        public static RoleInfo medium = new RoleInfo("Медиум", Medium.color, "Разговаривай с душами,чтобы победить", "Разговаривай с душами", RoleId.Medium);
        public static RoleInfo lawyer = new RoleInfo("Адвокат", Lawyer.color, "Защити своего клиента", "Защити своего клиента", RoleId.Lawyer, true);
        public static RoleInfo pursuer = new RoleInfo("Преследователь", Pursuer.color, "Запрети импостеров", "Запрети импостеров", RoleId.Pursuer);
        public static RoleInfo impostor = new RoleInfo("Импостор", Palette.ImpostorRed, Helpers.cs(Palette.ImpostorRed, "Саботируй и убей всех"), "Саботируй и убей всех", RoleId.Impostor);
        public static RoleInfo crewmate = new RoleInfo("Мирный", Color.white, "Найди импостеров", "Найди импостеров", RoleId.Crewmate);
        public static RoleInfo lover = new RoleInfo("Любовник", Lovers.color, $"Ты любовник", $"Ты любовник", RoleId.Lover);
        public static RoleInfo witch = new RoleInfo("Ведьма", Witch.color, "Кастуй заклинания,чтобы убить других", "Кастуй заклинания,чтобы убить других", RoleId.Witch); 
        public static RoleInfo phaser = new RoleInfo("Злой Прыгун", Phaser.color, "Поставь метку и убей", "Прокляни и убей всех", RoleId.Phaser);
        public static RoleInfo jumper = new RoleInfo("Прыгун", Jumper.color, "Удиви <color=#FF1919FF>Импостеров</color>", "Удиви импостеров", RoleId.Jumper);


        public static List<RoleInfo> allRoleInfos = new List<RoleInfo>() {
            impostor,
            godfather,
            mafioso,
            janitor,
            morphling,
            camouflager,
            vampire,
            eraser,
            trickster,
            cleaner,
            warlock,
            bountyHunter,
            witch,
            phaser,
            niceMini,
            evilMini,
            goodGuesser,
            badGuesser,
            lover,
            jester,
            arsonist,
            jackal,
            sidekick,
            vulture,
            pursuer,
            lawyer,
            crewmate,
            shifter,
            mayor,
            engineer,
            sheriff,
            deputy,
            lighter,
            detective,
            timeMaster,
            medic,
            swapper,
            seer,
            hacker,
            tracker,
            snitch,
            spy,
            securityGuard,
            bait,
            medium,
            jumper
        };

        public static List<RoleInfo> getRoleInfoForPlayer(PlayerControl p) {
            List<RoleInfo> infos = new List<RoleInfo>();
            if (p == null) return infos;

            // Special roles
            if (p == Jester.jester) infos.Add(jester);
            if (p == Mayor.mayor) infos.Add(mayor);
            if (p == Engineer.engineer) infos.Add(engineer);
            if (p == Sheriff.sheriff || p == Sheriff.formerSheriff) infos.Add(sheriff);
            if (p == Deputy.deputy) infos.Add(deputy);
            if (p == Lighter.lighter) infos.Add(lighter);
            if (p == Godfather.godfather) infos.Add(godfather);
            if (p == Mafioso.mafioso) infos.Add(mafioso);
            if (p == Janitor.janitor) infos.Add(janitor);
            if (p == Morphling.morphling) infos.Add(morphling);
            if (p == Camouflager.camouflager) infos.Add(camouflager);
            if (p == Vampire.vampire) infos.Add(vampire);
            if (p == Eraser.eraser) infos.Add(eraser);
            if (p == Trickster.trickster) infos.Add(trickster);
            if (p == Cleaner.cleaner) infos.Add(cleaner);
            if (p == Warlock.warlock) infos.Add(warlock);
            if (p == Witch.witch) infos.Add(witch);
            if (p == Phaser.phaser) infos.Add(phaser);
            if (p == Detective.detective) infos.Add(detective);
            if (p == TimeMaster.timeMaster) infos.Add(timeMaster);
            if (p == Medic.medic) infos.Add(medic);
            if (p == Shifter.shifter) infos.Add(shifter);
            if (p == Swapper.swapper) infos.Add(swapper);
            if (p == Seer.seer) infos.Add(seer);
            if (p == Hacker.hacker) infos.Add(hacker);
            if (p == Mini.mini) infos.Add(p.Data.Role.IsImpostor ? evilMini : niceMini);
            if (p == Tracker.tracker) infos.Add(tracker);
            if (p == Snitch.snitch) infos.Add(snitch);
            if (p == Jackal.jackal || (Jackal.formerJackals != null && Jackal.formerJackals.Any(x => x.PlayerId == p.PlayerId))) infos.Add(jackal);
            if (p == Sidekick.sidekick) infos.Add(sidekick);
            if (p == Spy.spy) infos.Add(spy);
            if (p == SecurityGuard.securityGuard) infos.Add(securityGuard);
            if (p == Arsonist.arsonist) infos.Add(arsonist);
            if (p == Guesser.niceGuesser) infos.Add(goodGuesser);
            if (p == Guesser.evilGuesser) infos.Add(badGuesser);
            if (p == BountyHunter.bountyHunter) infos.Add(bountyHunter);
            if (p == Bait.bait) infos.Add(bait);
            if (p == Vulture.vulture) infos.Add(vulture);
            if (p == Medium.medium) infos.Add(medium);
            if (p == Lawyer.lawyer) infos.Add(lawyer);
            if (p == Pursuer.pursuer) infos.Add(pursuer);
            if (p == Jumper.jumper) infos.Add(jumper);

            // Default roles
            if (infos.Count == 0 && p.Data.Role.IsImpostor) infos.Add(impostor); // Just Impostor
            if (infos.Count == 0 && !p.Data.Role.IsImpostor) infos.Add(crewmate); // Just Crewmate

            // Modifier
            if (p == Lovers.lover1|| p == Lovers.lover2) infos.Add(lover);

            return infos;
        }

        public static String GetRolesString(PlayerControl p, bool useColors) {
            string roleName;
            roleName = String.Join(" ", getRoleInfoForPlayer(p).Select(x => useColors ? Helpers.cs(x.color, x.name) : x.name).ToArray());
            if (Lawyer.target != null && p.PlayerId == Lawyer.target.PlayerId && PlayerControl.LocalPlayer != Lawyer.target) roleName += (useColors ? Helpers.cs(Pursuer.color, " §") : " §");
            return roleName;
        }
    }
}
