using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Menu;

namespace AkaCore.Manager
{
    class MenuManager
    {
        private static Menu HMenu, ActivatorMenu, UtilityMenu, OrbwalkerMenu, EvadeMenu, FPS;

        public static void Load()
        {
            Hauptmenu();
            Activatormenu();
            Utilitymenu();
            Orbwalkermenu();
            Evademenu();
            FPSMenu();
        }

        private static void Hauptmenu()
        {
            HMenu = MainMenu.AddMenu("Aka核心", "akacdsore");
            HMenu.AddGroupLabel("我的脚本外设.");
        }

        private static void Activatormenu()
        {
            ActivatorMenu = HMenu.AddSubMenu("活化剂", "Activator");
            ActivatorMenu.AddGroupLabel("进攻型物品");
            ActivatorMenu.Add("AItems", new CheckBox("使用物品"));
            ActivatorMenu.Add("Botrk", new CheckBox("使用 破败/弯刀"));
            ActivatorMenu.Add("Hydra", new CheckBox("使用 九头蛇/提亚马特"));
            ActivatorMenu.Add("Titanic", new CheckBox("使用 泰坦"));
            ActivatorMenu.Add("HGB", new CheckBox("使用 科技枪"));
            ActivatorMenu.Add("HGLP", new CheckBox("使用 科技枪 GLP"));
            ActivatorMenu.Add("HPB", new CheckBox("使用 火箭腰带"));
            ActivatorMenu.Add("Queens", new CheckBox("使用 冰霜指令"));
            ActivatorMenu.Add("QueensDis", new Slider("敌人范围 =>", 1500, 0, 3000));
            ActivatorMenu.Add("Glory", new CheckBox("使用 荣光"));
            ActivatorMenu.Add("GloryDis", new Slider("敌人范围 =>", 600, 0, 1000));
            ActivatorMenu.Add("Talis", new CheckBox("使用 飞升"));
            ActivatorMenu.Add("TalisDis", new Slider("敌人范围 =>", 1000, 0, 2000));
            ActivatorMenu.Add("You", new CheckBox("使用 幽梦"));
            ActivatorMenu.AddGroupLabel("防守型物品");
            ActivatorMenu.Add("DItems", new CheckBox("使用物品"));
            ActivatorMenu.Add("FaceMe", new CheckBox("对我使用山崇")); // The identifier tho kappa
            ActivatorMenu.Add("FaceMeHp", new Slider("如果我血量 <=", 20, 0, 100));
            ActivatorMenu.Add("FaceAlly", new CheckBox("对友军使用山崇"));
            ActivatorMenu.Add("FaceAllyHp", new Slider("如果友军血量p <=", 20, 0, 100));
            ActivatorMenu.Add("SolariMe", new CheckBox("使用 Iron Solari Me"));
            ActivatorMenu.Add("SolariMeHp", new Slider("如果我的血量 <=", 20, 0, 100));
            ActivatorMenu.Add("SolariAlly", new CheckBox("使用 Iron Solari Ally"));
            ActivatorMenu.Add("SolariAllyHp", new Slider("如果友军血量 <=", 20, 0, 100));
            ActivatorMenu.Add("Omen", new CheckBox("使用 兰盾"));
            ActivatorMenu.Add("OmenHp", new Slider("如果我的血量 <=", 20, 0, 100));
            ActivatorMenu.Add("Seraphs", new CheckBox("使用 大天使"));
            ActivatorMenu.Add("SeraphsHp", new Slider("如果我的血量 <=", 20, 0, 100));
            ActivatorMenu.Add("Talis2", new CheckBox("使用 飞升"));
            ActivatorMenu.Add("Talis2Hp", new Slider("如果我的血量 <=", 20, 0, 100));
            ActivatorMenu.Add("Glory2", new CheckBox("使用 荣光"));
            ActivatorMenu.Add("Glory2Hp", new Slider("如果我的血量 <=", 20, 0, 100));
            ActivatorMenu.Add("Zhonyas", new CheckBox("使用 中亚"));
            ActivatorMenu.Add("ZhonyasHp", new Slider("如果我的血量 <=", 20, 0, 100));
            ActivatorMenu.AddGroupLabel("药水");
            ActivatorMenu.Add("PItems", new CheckBox("使用 药水"));
            ActivatorMenu.Add("HPPot", new CheckBox("使用 红药"));
            ActivatorMenu.Add("HPPotHp", new Slider("如果我的血量 <=", 40, 0, 100));
            ActivatorMenu.Add("Biscuit", new CheckBox("使用 饼干"));
            ActivatorMenu.Add("BiscuitHp", new Slider("如果我的血量 <=", 40, 0, 100));
            ActivatorMenu.Add("RefillPot", new CheckBox("使用 充能药水"));
            ActivatorMenu.Add("RefillPotHp", new Slider("如果我的血量 <=", 60, 0, 100));
            ActivatorMenu.Add("HunterPot", new CheckBox("使用 猎人药水"));
            ActivatorMenu.Add("HunterPotHp", new Slider("如果我的血量 <=", 60, 0, 100));
            ActivatorMenu.Add("CorruptPot", new CheckBox("使用 腐蚀药水"));
            ActivatorMenu.Add("CourrptPotHp", new Slider("如果我的血量 <=", 60, 0, 100));
            ActivatorMenu.AddGroupLabel("召唤兽技能");
            ActivatorMenu.Add("Heal", new CheckBox("治疗"));
            ActivatorMenu.Add("HealHp", new Slider("治疗 如果我的血量 <=", 20, 0, 100));
            ActivatorMenu.Add("HealAlly", new CheckBox("治疗 友军"));
            ActivatorMenu.Add("HealAllyHp", new Slider("治疗 如果友军血量 <=", 20, 0, 100));
            ActivatorMenu.Add("Barrier", new CheckBox("护盾"));
            ActivatorMenu.Add("BarrierHp", new Slider("护盾 如果我的血量 <=", 20, 0, 100));
            ActivatorMenu.Add("Ignite", new CheckBox("使用 点燃"));
            ActivatorMenu.Add("IgniteHp", new Slider("0 抢头 除非血量 <=", 0, 0, 100));
            ActivatorMenu.Add("Exhaust", new CheckBox("使用 虚弱"));
            ActivatorMenu.Add("ExhaustHp", new Slider("虚弱如果敌人血量 <=", 40, 0, 100));
            ActivatorMenu.AddGroupLabel("惩戒");
            ActivatorMenu.Add("SmiteActive", new KeyBind("开启惩戒", true, KeyBind.BindTypes.PressToggle));
            ActivatorMenu.Add("SStatus", new CheckBox("显示状态"));
            ActivatorMenu.Add("SDamage", new CheckBox("显示伤害"));
            ActivatorMenu.Add("SBaron", new CheckBox("大龙"));
            ActivatorMenu.Add("SHerald", new CheckBox("先锋"));
            ActivatorMenu.Add("SWDragon", new CheckBox("水龙"));
            ActivatorMenu.Add("SFDragon", new CheckBox("火龙"));
            ActivatorMenu.Add("SEDragon", new CheckBox("土龙"));
            ActivatorMenu.Add("SADragon", new CheckBox("云龙"));
            ActivatorMenu.Add("SElder", new CheckBox("长者龙"));
            ActivatorMenu.Add("SBlue", new CheckBox("蓝", false));
            ActivatorMenu.Add("SRed", new CheckBox("红", false));
            ActivatorMenu.Add("SRaptor", new CheckBox("鸟", false));
            ActivatorMenu.Add("SWolf", new CheckBox("狼", false));
            ActivatorMenu.Add("SGromp", new CheckBox("青蛙", false));
            ActivatorMenu.Add("SKrug", new CheckBox("石头人", false));
            ActivatorMenu.Add("SCrap", new CheckBox("河蟹", false));
            ActivatorMenu.AddGroupLabel("净化");
            ActivatorMenu.Add("Qss", new CheckBox("使用 水银"));
            ActivatorMenu.Add("Mecurial", new CheckBox("使用 水银弯刀"));
            ActivatorMenu.Add("Cleanser", new CheckBox("使用 净化"));
            ActivatorMenu.Add("QssDelay", new Slider("延迟", 100, 0, 2000));
            ActivatorMenu.Add("Blind",
                new CheckBox("致盲", false));
            ActivatorMenu.Add("Charm",
                new CheckBox("魅惑"));
            ActivatorMenu.Add("Fear",
                new CheckBox("恐惧"));
            ActivatorMenu.Add("Polymorph",
                new CheckBox("变形"));
            ActivatorMenu.Add("Stun",
                new CheckBox("晕眩"));
            ActivatorMenu.Add("Snare",
                new CheckBox("定身"));
            ActivatorMenu.Add("Silence",
                new CheckBox("沉默", false));
            ActivatorMenu.Add("Taunt",
                new CheckBox("嘲讽"));
            ActivatorMenu.Add("Suppression",
                new CheckBox("压制"));
        }

        private static void Utilitymenu()
        {
            UtilityMenu = HMenu.AddSubMenu("功能", "kappa");
            UtilityMenu.AddGroupLabel("功能");
            UtilityMenu.Add("Skinhack", new CheckBox("开启换肤", false));
            UtilityMenu.Add("SkinID", new Slider("SkinID", 0, 0, 15));
            UtilityMenu.Add("Autolvl", new CheckBox("开启自动加点"));
            UtilityMenu.Add("AutolvlS", new ComboBox("加点模式", 0, "主 Q", "主 W", "主 E"));
            UtilityMenu.Add("Autobuy", new CheckBox("开局自动购买"));
            UtilityMenu.Add("AutobuyS", new ComboBox("开局物品", 0, "多兰剑", "多兰戒", "多兰盾", "腐蚀药水", "猎人药水", "猎人刀", "古钱币", "法术盗贼的匕首", "遗迹圣盾"));
            UtilityMenu.Add("Autobuyt", new CheckBox("升级饰品"));
            UtilityMenu.Add("AutobuytS", new ComboBox("升级到", 0, "远见", "真视"));
            UtilityMenu.Add("Autolantern", new CheckBox("自动灯笼"));
            UtilityMenu.Add("AutolanternHP", new Slider("自动灯笼如果血量 =>", 40));
        }

        private static void Orbwalkermenu()
        {
            OrbwalkerMenu = HMenu.AddSubMenu("走砍", "asdasf");
            OrbwalkerMenu.AddGroupLabel("走砍扩展");
            if (ObjectManager.Player.ChampionName == "Draven")
            {
                OrbwalkerMenu.AddGroupLabel("自动接斧");
                OrbwalkerMenu.Add("Qmode", new ComboBox("接斧模式", 1, "连招", "一直", "从不"));
                OrbwalkerMenu.Add("Qrange", new Slider("接斧范围:", 800, 120, 1500));
                OrbwalkerMenu.Add("WforQ", new CheckBox("使用 W 如果斧头太远"));
                OrbwalkerMenu.AddGroupLabel("安全设置");
                OrbwalkerMenu.Add("Qturret", new CheckBox("塔下不接"));
                OrbwalkerMenu.Add("Qenemies", new CheckBox("敌人群中不接"));
                OrbwalkerMenu.Add("Qkill", new CheckBox("可击杀敌人不接"));
                OrbwalkerMenu.Add("Qmelee", new CheckBox("近距离敌人不接"));
                OrbwalkerMenu.AddGroupLabel("线圈");
                OrbwalkerMenu.Add("DrawAxe", new CheckBox("显示斧头"));
                OrbwalkerMenu.Add("DrawAxeRange", new CheckBox("显示接斧范围"));

            }
            else
            {
                OrbwalkerMenu.AddGroupLabel("德莱文专用");
            }
        }

        private static void Evademenu()
        {
            EvadeMenu = HMenu.AddSubMenu("躲避", "asddsf");
            EvadeMenu.AddGroupLabel("躲避");
            EvadeMenu.AddGroupLabel("啥都没 :(");
        }

        private static void FPSMenu()
        {
            FPS = HMenu.AddSubMenu("FPS 保护", "asd");
            //FPS.AddGroupLabel("This is only working with my addons :/");
            
            FPS.Add("minfps", new Slider("最低 Fps", 45, 1, 350));
            FPS.Add("calcps", new Slider("每秒计算 per Sec", 35, 1, 350));
            FPS.Add("enablefps", new CheckBox("开启 FPS 保护"));
        }

        #region checkvalues
        #region checkvalues:activator
        //pots
        public static bool HPPot
        {
            get { return (ActivatorMenu["HPPot"].Cast<CheckBox>().CurrentValue); }
        }

        public static int HPPotHp
        {
            get { return (ActivatorMenu["HPPotHp"].Cast<Slider>().CurrentValue); }
        }

        public static bool Biscuit
        {
            get { return (ActivatorMenu["Biscuit"].Cast<CheckBox>().CurrentValue); }
        }

        public static int BiscuitHp
        {
            get { return (ActivatorMenu["BiscuitHp"].Cast<Slider>().CurrentValue); }
        }

        public static bool RefillPot
        {
            get { return (ActivatorMenu["RefillPot"].Cast<CheckBox>().CurrentValue); }
        }

        public static int RefillPotHp
        {
            get { return (ActivatorMenu["RefillPotHp"].Cast<Slider>().CurrentValue); }
        }

        public static bool HunterPot
        {
            get { return (ActivatorMenu["HunterPot"].Cast<CheckBox>().CurrentValue); }
        }

        public static int HunterPotHp
        {
            get { return (ActivatorMenu["HunterPotHp"].Cast<Slider>().CurrentValue); }
        }

        public static bool CorruptPot
        {
            get { return (ActivatorMenu["CorruptPot"].Cast<CheckBox>().CurrentValue); }
        }

        public static int CorruptPotHp
        {
            get { return (ActivatorMenu["CorruptPotHp"].Cast<Slider>().CurrentValue); }
        }
        //Aggressiveive
        public static bool Botrk
        {
            get { return (ActivatorMenu["Botrk"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool Hextech
        {
            get { return (ActivatorMenu["HGB"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool HextechGLP
        {
            get { return (ActivatorMenu["HGLP"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool HextechPB
        {
            get { return (ActivatorMenu["HPB"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool Hydra
        {
            get { return (ActivatorMenu["Hydra"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool Titanic
        {
            get { return (ActivatorMenu["Titanic"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool Queens
        {
            get { return (ActivatorMenu["Queens"].Cast<CheckBox>().CurrentValue); }
        }

        public static int QueensDistance
        {
            get { return (ActivatorMenu["QueensDis"].Cast<Slider>().CurrentValue); }
        }

        public static bool Glory
        {
            get { return (ActivatorMenu["Glory"].Cast<CheckBox>().CurrentValue); }
        }

        public static int GloryDistance
        {
            get { return (ActivatorMenu["GloryDis"].Cast<Slider>().CurrentValue); }
        }

        public static bool Talis
        {
            get { return (ActivatorMenu["Talis"].Cast<CheckBox>().CurrentValue); }
        }

        public static int TalisDistance
        {
            get { return (ActivatorMenu["TalisDis"].Cast<Slider>().CurrentValue); }
        }

        public static bool You
        {
            get { return (ActivatorMenu["You"].Cast<CheckBox>().CurrentValue); }
        }
        //Defensive
        public static bool MountainMe
        {
            get { return (ActivatorMenu["FaceMe"].Cast<CheckBox>().CurrentValue); }
        }

        public static int MountainMeHp
        {
            get { return (ActivatorMenu["FaceMeHp"].Cast<Slider>().CurrentValue); }
        }

        public static bool MountainAlly
        {
            get { return (ActivatorMenu["FaceAlly"].Cast<CheckBox>().CurrentValue); }
        }

        public static int MoutaiAllyHp
        {
            get { return (ActivatorMenu["FaceAllyHp"].Cast<Slider>().CurrentValue); }
        }

        public static bool SolariMe
        {
            get { return (ActivatorMenu["SolariMe"].Cast<CheckBox>().CurrentValue); }
        }

        public static int SolraiMeHp
        {
            get { return (ActivatorMenu["SolariMeHp"].Cast<Slider>().CurrentValue); }
        }

        public static bool SolariAlly
        {
            get { return (ActivatorMenu["SolariAlly"].Cast<CheckBox>().CurrentValue); }
        }

        public static int SolraiAllyHp
        {
            get { return (ActivatorMenu["SolariAllyHp"].Cast<Slider>().CurrentValue); }
        }

        public static bool Omen
        {
            get { return (ActivatorMenu["Omen"].Cast<CheckBox>().CurrentValue); }
        }

        public static int OmenHp
        {
            get { return (ActivatorMenu["OmenHp"].Cast<Slider>().CurrentValue); }
        }

        public static bool Seraphs
        {
            get { return (ActivatorMenu["Seraphs"].Cast<CheckBox>().CurrentValue); }
        }

        public static int SeraphsHp
        {
            get { return (ActivatorMenu["SerahpsHp"].Cast<Slider>().CurrentValue); }
        }

        public static bool TalisDef
        {
            get { return (ActivatorMenu["Talis2"].Cast<CheckBox>().CurrentValue); }
        }

        public static int TalisDefHp
        {
            get { return (ActivatorMenu["Talis2Hp"].Cast<Slider>().CurrentValue); }
        }

        public static bool GloryDef
        {
            get { return (ActivatorMenu["Glory2"].Cast<CheckBox>().CurrentValue); }
        }

        public static int GloryDefHp
        {
            get { return (ActivatorMenu["Glory2Hp"].Cast<Slider>().CurrentValue); }
        }

        public static bool Zhonyas
        {
            get { return (ActivatorMenu["Zhonyas"].Cast<CheckBox>().CurrentValue); }
        }

        public static int ZhonyasHp
        {
            get { return (ActivatorMenu["ZhonyasHp"].Cast<Slider>().CurrentValue); }
        }

        //Summoososos
        public static bool Heal
        {
            get { return (ActivatorMenu["Heal"].Cast<CheckBox>().CurrentValue); }
        }

        public static int HealHp
        {
            get { return (ActivatorMenu["HealHp"].Cast<Slider>().CurrentValue); }
        }

        public static bool Barrier
        {
            get { return (ActivatorMenu["Barrier"].Cast<CheckBox>().CurrentValue); }
        }

        public static int BarrierHp
        {
            get { return (ActivatorMenu["BarrierHp"].Cast<Slider>().CurrentValue); }
        }

        public static bool HealAlly
        {
            get { return (ActivatorMenu["HealAlly"].Cast<CheckBox>().CurrentValue); }
        }

        public static int HealAllyHp
        {
            get { return (ActivatorMenu["HealAllyHp"].Cast<Slider>().CurrentValue); }
        }

        public static bool Ignite
        {
            get { return (ActivatorMenu["Ignite"].Cast<CheckBox>().CurrentValue); }
        }

        public static int IgniteHp
        {
            get { return (ActivatorMenu["IgniteHp"].Cast<Slider>().CurrentValue); }
        }

        public static bool Exhaust
        {
            get { return (ActivatorMenu["Exhaust"].Cast<CheckBox>().CurrentValue); }
        }

        public static int ExhaustHp
        {
            get { return (ActivatorMenu["ExhaustHp"].Cast<Slider>().CurrentValue); }
        }
        //smite
        public static bool SmiteActive
        {
            get { return (ActivatorMenu["SmiteActive"].Cast<KeyBind>().CurrentValue); }
        }
        public static bool SStatus
        {
            get { return (ActivatorMenu["SStatus"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool SDamage
        {
            get { return (ActivatorMenu["SDamage"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool SBaron
        {
            get { return (ActivatorMenu["SBaron"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool SHerald
        {
            get { return (ActivatorMenu["SHerald"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool SWDragon
        {
            get { return (ActivatorMenu["SWDragon"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool SEDragon
        {
            get { return (ActivatorMenu["SEDragon"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool SADragon
        {
            get { return (ActivatorMenu["SADragon"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool SFDragon
        {
            get { return (ActivatorMenu["SFDragon"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool Elder
        {
            get { return (ActivatorMenu["SElder"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool SBlue
        {
            get { return (ActivatorMenu["SBlue"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool SRaptor
        {
            get { return (ActivatorMenu["SRaptor"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool SRed
        {
            get { return (ActivatorMenu["SRed"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool SWolf
        {
            get { return (ActivatorMenu["SWolf"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool SKrug
        {
            get { return (ActivatorMenu["SKrug"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool SGromp
        {
            get { return (ActivatorMenu["SGromp"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool SGrap
        {
            get { return (ActivatorMenu["SCrap"].Cast<CheckBox>().CurrentValue); }
        }
        //Qssss
        public static bool Qss
        {
            get { return (ActivatorMenu["Qss"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool Mecurial
        {
            get { return (ActivatorMenu["Mecurial"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool Cleanse
        {
            get { return (ActivatorMenu["Cleanser"].Cast<CheckBox>().CurrentValue); }
        }

        public static int QssDelay
        {
            get { return (ActivatorMenu["QssDelay"].Cast<Slider>().CurrentValue); }
        }

        public static bool QssBlind
        {
            get { return (ActivatorMenu["Blind"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool QssCharm
        {
            get { return (ActivatorMenu["Charm"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool QssFear
        {
            get { return (ActivatorMenu["Fear"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool QssPolymorph
        {
            get { return (ActivatorMenu["Polymorph"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool QssStun
        {
            get { return (ActivatorMenu["Stun"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool QssSnare
        {
            get { return (ActivatorMenu["Snare"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool QssSilence
        {
            get { return (ActivatorMenu["Silence"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool QssTaunt
        {
            get { return (ActivatorMenu["Taunt"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool QssSupression
        {
            get { return (ActivatorMenu["Suppression"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool AItems
        {
            get { return (ActivatorMenu["AItems"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool DItems
        {
            get { return (ActivatorMenu["DItems"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool PItems
        {
            get { return (ActivatorMenu["PItems"].Cast<CheckBox>().CurrentValue); }
        }
        #endregion
        #region checkvalues:utility
        public static bool Skinhack
        {
            get { return (UtilityMenu["Skinhack"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool Autolvl
        {
            get { return (UtilityMenu["Autolvl"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool Autobuy
        {
            get { return (UtilityMenu["Autobuy"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool Autobuytrinkets
        {
            get { return (UtilityMenu["Autobuyt"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool Autolantern
        {
            get { return (UtilityMenu["Autolantern"].Cast<CheckBox>().CurrentValue); }
        }
        public static int SkinID
        {
            get { return (UtilityMenu["SkinID"].Cast<Slider>().CurrentValue); }
        }
        public static int AutolvlSlider
        {
            get { return (UtilityMenu["AutolvlS"].Cast<ComboBox>().CurrentValue); }
        }
        public static int AutobuySlider
        {
            get { return (UtilityMenu["AutobuyS"].Cast<ComboBox>().CurrentValue); }
        }
        public static int AutobuytrinketsSlider
        {
            get { return (UtilityMenu["AutobuytS"].Cast<ComboBox>().CurrentValue); }
        }
        public static int AutlanternHp
        {
            get { return (UtilityMenu["AutolanternHP"].Cast<Slider>().CurrentValue); }
        }
        #endregion
        #region checkvalues:orbwalk
        #region autocatch
        #region Axe
        public static int AxeMode
        {
            get { return (OrbwalkerMenu["Qmode"].Cast<ComboBox>().CurrentValue); }
        }
        public static int AxeCatchRange
        {
            get { return (OrbwalkerMenu["Qrange"].Cast<Slider>().CurrentValue); }
        }
        public static bool AxeW
        {
            get { return (OrbwalkerMenu["WforQ"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool DrawAxe
        {
            get { return (OrbwalkerMenu["DrawAxe"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool DrawAxeCatchRange
        {
            get { return (OrbwalkerMenu["DrawAxeRange"].Cast<CheckBox>().CurrentValue); }
        }
        #endregion
        #region safety
        public static bool CatchTower
        {
            get { return (OrbwalkerMenu["Qturret"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool CatchEnemies
        {
            get { return (OrbwalkerMenu["Qenemies"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool CatchKill
        {
            get { return (OrbwalkerMenu["Qkill"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool CatchMelees
        {
            get { return (OrbwalkerMenu["Qmelee"].Cast<CheckBox>().CurrentValue); }
        }
        #endregion
        #endregion
        #endregion
        #region checkvalues:fps

        public static int MinFps
        {
            get { return (FPS["minfps"].Cast<Slider>().CurrentValue); }
        }

        public static int CalcPerSecond
        {
            get { return (FPS["calcps"].Cast<Slider>().CurrentValue); }
        }

        public static bool EnableFPS
        {
            get { return (FPS["enablefps"].Cast<CheckBox>().CurrentValue); }
        }
        #endregion
        #endregion
    }
}
