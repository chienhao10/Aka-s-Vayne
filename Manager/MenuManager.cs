using System;
using EloBuddy.SDK;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aka_s_Vayne.Manager
{
    class MenuManager
    {
        private static Menu VMenu,
            Hotkeymenu,
            Qsettings,
            ComboMenu,
            CondemnMenu,
            HarassMenu,
            FleeMenu,
            LaneClearMenu,
            JungleClearMenu,
            MiscMenu,
            DrawingMenu;

        public static void Load()
        {
            Mainmenu();
            Hotkeys();
            Combomenu();
            QSettings();
            Condemnmenu();
            Harassmenu();
            Fleemenu();
            LaneClearmenu();
            JungleClearmenu();
            Miscmenu();
            Drawingmenu();
        }

        private static void Mainmenu()
        {
            VMenu = MainMenu.AddMenu("Aka´s 薇恩", "akavayne");
            VMenu.AddGroupLabel("Welcome to my Vayne Addon have fun! :)");
            VMenu.AddGroupLabel("作者：Aka CH汉化*-*");
        }

        private static void Hotkeys()
        {
            Hotkeymenu = VMenu.AddSubMenu("快捷键", "Hotkeys");
            Hotkeymenu.Add("flashe", new KeyBind("闪现定墙!", false, KeyBind.BindTypes.HoldActive, 'Y'));
            Hotkeymenu.Add("insece", new KeyBind("闪现 推人!", false, KeyBind.BindTypes.HoldActive, 'Z'));
            Hotkeymenu.Add("rote", new KeyBind("传送门定墙!", false, KeyBind.BindTypes.HoldActive, 'N'));
            Hotkeymenu.Add("autopos", new KeyBind("自动走位(beta)", false, KeyBind.BindTypes.HoldActive, 'K'));
            Hotkeymenu.Add("insecmodes", new ComboBox("推人模式", 0, "至友军", "至塔下", "至鼠标"));
            Hotkeymenu.Add("RnoAA", new KeyBind("隐身时不普攻", false, KeyBind.BindTypes.PressToggle, 'T'));
            Hotkeymenu.Add("RnoAAif", new Slider("当附近 X 敌人隐身时不普攻 >= enemy in range", 2, 0, 5));
        }

        private static void Combomenu()
        {
            ComboMenu = VMenu.AddSubMenu("连招", "Combo");
            ComboMenu.AddGroupLabel("连招");
            ComboMenu.AddGroupLabel("Q 模式");
            ComboMenu.AddLabel("智能模式!");
            var qmode = ComboMenu.Add("Qmode", new ComboBox("Q 模式", 1, "鼠标", "智能", "风筝", "旧版", "新版"));
            qmode.OnValueChange += delegate
            {
                if (qmode.CurrentValue == 1)
                {
                    Qsettings["UseSafeQ"].IsVisible = true;
                    Qsettings["UseQEnemies"].IsVisible = true;
                    Qsettings["UseQSpam"].IsVisible = true;
                    ComboMenu["Qmode2"].IsVisible = true;
                    Qsettings["QNMode"].IsVisible = false;
                    Qsettings["QNEnemies"].IsVisible = false;
                    Qsettings["QNWall"].IsVisible = false;
                    Qsettings["QNTurret"].IsVisible = false;
                }
                if (qmode.CurrentValue == 3)
                {
                    ComboMenu["Qmode2"].IsVisible = false;
                    Qsettings["UseSafeQ"].IsVisible = false;
                    Qsettings["UseQEnemies"].IsVisible = false;
                    Qsettings["UseQSpam"].IsVisible = false;
                    Qsettings["QNMode"].IsVisible = false;
                    Qsettings["QNEnemies"].IsVisible = false;
                    Qsettings["QNWall"].IsVisible = false;
                    Qsettings["QNTurret"].IsVisible = false;
                }
                if (qmode.CurrentValue == 2)
                {
                    ComboMenu["Qmode2"].IsVisible = false;
                    Qsettings["UseSafeQ"].IsVisible = false;
                    Qsettings["UseQEnemies"].IsVisible = false;
                    Qsettings["UseQSpam"].IsVisible = false;
                    Qsettings["QNMode"].IsVisible = false;
                    Qsettings["QNEnemies"].IsVisible = false;
                    Qsettings["QNWall"].IsVisible = false;
                    Qsettings["QNTurret"].IsVisible = false;
                }
                if (qmode.CurrentValue == 0)
                {
                    ComboMenu["Qmode2"].IsVisible = false;
                    Qsettings["UseSafeQ"].IsVisible = false;
                    Qsettings["UseQEnemies"].IsVisible = false;
                    Qsettings["UseQSpam"].IsVisible = false;
                    Qsettings["QNMode"].IsVisible = false;
                    Qsettings["QNEnemies"].IsVisible = false;
                    Qsettings["QNWall"].IsVisible = false;
                    Qsettings["QNTurret"].IsVisible = false;
                }
                if (qmode.CurrentValue == 4)
                {
                    ComboMenu["Qmode2"].IsVisible = false;
                    Qsettings["UseSafeQ"].IsVisible = false;
                    Qsettings["UseQEnemies"].IsVisible = false;
                    Qsettings["UseQSpam"].IsVisible = false;
                    Qsettings["QNMode"].IsVisible = true;
                    Qsettings["QNEnemies"].IsVisible = true;
                    Qsettings["QNWall"].IsVisible = true;
                    Qsettings["QNTurret"].IsVisible = true;
                }
            };
            ComboMenu.Add("Qmode2", new ComboBox("智能模式", 0, "进攻型", "防守型")).IsVisible = true;
            ComboMenu.Add("UseQwhen", new ComboBox("使用 Q", 0, "普攻前", "普攻后", "从不"));
            ComboMenu.AddGroupLabel("W 设置");
            ComboMenu.Add("UseW", new CheckBox("集火 W", false));
            ComboMenu.AddGroupLabel("E 设置");
            ComboMenu.Add("UseE", new CheckBox("使用 E"));
            ComboMenu.Add("UseEKill", new CheckBox("使用 E 如果可击杀?"));
            ComboMenu.AddGroupLabel("R 设置");
            ComboMenu.Add("UseR", new CheckBox("使用 R", false));
            ComboMenu.Add("UseRif", new Slider("使用 R 如果敌人有x个", 2, 1, 5));
        }

        public static void QSettings()
        {
            Qsettings = VMenu.AddSubMenu("Q 设置", "Q Settings");
            Qsettings.AddGroupLabel("Q 设置");
            Qsettings.AddLabel("爆发模式会Q进墙进行普攻重置.");
            Qsettings.Add("UseMirinQ", new CheckBox("爆发模式"));
            Qsettings.Add("UseQE", new CheckBox("尝试 QE?", false));
            //smart
            Qsettings.Add("UseSafeQ", new CheckBox("使用动态 Q 安全检查?", false)).IsVisible = true;
            Qsettings.Add("UseQEnemies", new CheckBox("不 Q 进敌人?", false)).IsVisible = true;
            Qsettings.Add("UseQSpam", new CheckBox("无视检查", false)).IsVisible = true;
            //new
            Qsettings.Add("QNMode", new ComboBox("新版模式", 1, "边上", "安全位置")).IsVisible = false;
            Qsettings.Add("QNEnemies", new Slider("屏蔽Q 当有x敌人", 3, 5, 0)).IsVisible = false;
            Qsettings.Add("QNWall", new CheckBox("屏蔽Q撞墙", true)).IsVisible = false;
            Qsettings.Add("QNTurret", new CheckBox("屏蔽Q进塔下", true)).IsVisible = false;
        }

        public static void Condemnmenu()
        {
            CondemnMenu = VMenu.AddSubMenu("定墙", "Condemn");
            CondemnMenu.AddGroupLabel("定墙");
            CondemnMenu.AddLabel("ACV>Best>Shine>Old>Marksman（指ACV最好的意思）");
            CondemnMenu.Add("Condemnmode", new ComboBox("定墙模式", 4, "Best", "Old", "Marksman", "Shine", "ACV"));
            CondemnMenu.Add("UseEAuto", new CheckBox("自动 E"));
            CondemnMenu.Add("UseETarget", new CheckBox("只晕眩当前目标?", false));
            CondemnMenu.Add("UseEHitchance", new Slider("晕眩命中率", 2, 1, 4));
            CondemnMenu.Add("UseEPush", new Slider("E 推行距离", 420, 350, 470));
            CondemnMenu.Add("UseEAA", new Slider("不 E 如果敌人可被普攻 x 下", 0, 0, 4));
            CondemnMenu.Add("AutoTrinket", new CheckBox("草丛饰品?"));
            CondemnMenu.Add("J4Flag", new CheckBox("E皇子旗子?"));
        }

        private static void Harassmenu()
        {
            HarassMenu = VMenu.AddSubMenu("骚扰", "Harass");
            HarassMenu.Add("HarassCombo", new CheckBox("骚扰连招"));
            HarassMenu.Add("HarassMana", new Slider("骚扰连招蓝量", 40));
        }

        private static void LaneClearmenu()
        {
            LaneClearMenu = VMenu.AddSubMenu("清线", "LaneClear");
            LaneClearMenu.Add("UseQ", new CheckBox("使用 Q"));
            LaneClearMenu.Add("UseQMana", new Slider("最大蓝量使用百分比({0}%)", 40));
        }

        private static void JungleClearmenu()
        {
            JungleClearMenu = VMenu.AddSubMenu("清野", "JungleClear");
            JungleClearMenu.Add("UseQ", new CheckBox("使用 Q"));
            JungleClearMenu.Add("UseE", new CheckBox("使用 E"));
        }

        private static void Fleemenu()
        {
            FleeMenu = VMenu.AddSubMenu("逃跑", "Flee");
            FleeMenu.Add("UseQ", new CheckBox("使用 Q"));
            FleeMenu.Add("UseE", new CheckBox("使用 E"));
        }

        private static void Miscmenu()
        {
            MiscMenu = VMenu.AddSubMenu("杂项", "Misc");
            MiscMenu.AddGroupLabel("杂项");
            MiscMenu.Add("GapcloseQ", new CheckBox("防突进 Q"));
            MiscMenu.Add("GapcloseE", new CheckBox("防突进 E"));
            MiscMenu.Add("InterruptE", new CheckBox("技能打断 E"));
            MiscMenu.Add("LowLifeE", new CheckBox("低血量 E", false));
            MiscMenu.Add("LowLifeES", new Slider("低血量 E 如果 =>", 20));

        }

        private static void Drawingmenu()
        {
            DrawingMenu = VMenu.AddSubMenu("线圈", "Drawings");
            DrawingMenu.Add("DrawQ", new CheckBox("显示 Q", false));
            DrawingMenu.Add("DrawE", new CheckBox("显示 E", false));
            DrawingMenu.Add("DrawOnlyReady", new CheckBox("只显示无冷却技能"));
            DrawingMenu.AddGroupLabel("预判");
            DrawingMenu.Add("DrawCondemn", new CheckBox("显示定墙"));
            DrawingMenu.Add("DrawTumble", new CheckBox("显示Q"));
            DrawingMenu.Add("DrawAutoPos", new CheckBox("显示自动喝药"));
        }

        #region checkvalues
        #region checkvalues:hotkeys
        public static bool AutoPos
        {
            get { return (Hotkeymenu["autopos"].Cast<KeyBind>().CurrentValue); }
        }
        public static bool FlashE
        {
            get { return (Hotkeymenu["flashe"].Cast<KeyBind>().CurrentValue); }
        }
        public static bool InsecE
        {
            get { return (Hotkeymenu["insece"].Cast<KeyBind>().CurrentValue); }
        }
        public static bool RotE
        {
            get { return (Hotkeymenu["rote"].Cast<KeyBind>().CurrentValue); }
        }
        public static int InsecPositions
        {
            get { return (Hotkeymenu["insecmodes"].Cast<ComboBox>().CurrentValue); }
        }
        public static bool RNoAA
        {
            get { return (Hotkeymenu["RnoAA"].Cast<KeyBind>().CurrentValue); }
        }
        public static int RNoAASlider
        {
            get { return (Hotkeymenu["RnoAAif"].Cast<Slider>().CurrentValue); }
        }
        #endregion checkvalues:hotkeys
        #region checkvalues:qsettings
        public static bool Burstmode
        {
            get { return (Qsettings["UseMirinQ"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool UseQE
        {
            get { return (Qsettings["UseQE"].Cast<CheckBox>().CurrentValue); }
        }
        //smart
        public static bool Dynamicsafety
        {
            get { return (Qsettings["UseSafeQ"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool DontuseQintoenemies
        {
            get { return (Qsettings["UseQEnemies"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool SpamQ
        {
            get { return (Qsettings["UseQSpam"].Cast<CheckBox>().CurrentValue); }
        }
        //new
        public static int QNMode
        {
            get { return (Qsettings["QNMode"].Cast<ComboBox>().CurrentValue); }
        }
        public static int QNEnemies
        {
            get { return (Qsettings["QNEnemies"].Cast<Slider>().CurrentValue); }
        }
        public static bool QNWall
        {
            get { return (Qsettings["QNWall"].Cast<CheckBox>().CurrentValue); }
        }
        public static bool QNTurret
        {
            get { return (Qsettings["QNTurret"].Cast<CheckBox>().CurrentValue); }
        }
        #endregion
        #region checkvalues:Combo
        public static int UseQMode
        {
            get { return (ComboMenu["Qmode"].Cast<ComboBox>().CurrentValue); }
        }

        public static int UseQMode2
        {
            get { return (ComboMenu["Qmode2"].Cast<ComboBox>().CurrentValue); }
        }

        public static int UseQif
        {
            get { return (ComboMenu["UseQwhen"].Cast<ComboBox>().CurrentValue); }
        }

        public static bool FocusW
        {
            get { return (ComboMenu["UseW"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool UseE
        {
            get { return (ComboMenu["UseE"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool UseEKill
        {
            get { return (ComboMenu["UseEKill"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool UseR
        {
            get { return (ComboMenu["UseR"].Cast<CheckBox>().CurrentValue); }
        }

        public static int UseRSlider
        {
            get { return (ComboMenu["UseRif"].Cast<Slider>().CurrentValue); }
        }
        //Condemn
        #endregion checkvalues:Combo
        #region checkvalues:Condemn
        public static int CondemnMode
        {
            get { return (CondemnMenu["Condemnmode"].Cast<ComboBox>().CurrentValue); }
        }

        public static bool AutoE
        {
            get { return (CondemnMenu["UseEAuto"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool OnlyStunCurrentTarget
        {
            get { return (CondemnMenu["UseETarget"].Cast<CheckBox>().CurrentValue); }
        }

        public static int CondemnHitchance
        {
            get { return (CondemnMenu["UseEHitchance"].Cast<Slider>().CurrentValue); }
        }

        public static int CondemnPushDistance
        {
            get { return (CondemnMenu["UseEPush"].Cast<Slider>().CurrentValue); }
        }

        public static int CondemnBlock
        {
            get { return (CondemnMenu["UseEAA"].Cast<Slider>().CurrentValue); }
        }

        public static bool AutoTrinket
        {
            get { return (CondemnMenu["AutoTrinket"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool J4Flag
        {
            get { return (CondemnMenu["J4Flag"].Cast<CheckBox>().CurrentValue); }
        }

        #endregion checkvalues:Condemn
        #region checkvalues:Harass

        public static bool HarassCombo
        {
            get { return (HarassMenu["HarassCombo"].Cast<CheckBox>().CurrentValue); }
        }

        public static int HarassMana
        {
            get { return (HarassMenu["HarassMana"].Cast<Slider>().CurrentValue); }
        }


        #endregion checkvalues:Harass
        #region checkvalues:LC

        public static bool UseQLC
        {
            get { return (LaneClearMenu["UseQ"].Cast<CheckBox>().CurrentValue); }
        }

        public static int UseQLCMana
        {
            get { return (LaneClearMenu["UseQMana"].Cast<Slider>().CurrentValue); }
        }


        #endregion checkvalues:LC
        #region checkvalues:JC

        public static bool UseQJC
        {
            get { return (JungleClearMenu["UseQ"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool UseEJC
        {
            get { return (JungleClearMenu["UseE"].Cast<CheckBox>().CurrentValue); }
        }

        #endregion checkvalues:JC
        #region checkvalues:Flee
        public static bool UseQFlee
        {
            get { return (FleeMenu["UseQ"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool UseEFlee
        {
            get { return (FleeMenu["UseE"].Cast<CheckBox>().CurrentValue); }
        }

        #endregion checkvalues:Flee
        #region checkvalues:Misc

        public static bool GapcloseQ
        {
            get { return (MiscMenu["GapcloseQ"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool GapcloseE
        {
            get { return (MiscMenu["GapcloseE"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool InterruptE
        {
            get { return (MiscMenu["InterruptE"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool LowLifeE
        {
            get { return (MiscMenu["LowLifeE"].Cast<CheckBox>().CurrentValue); }
        }

        public static int LowLifeESlider
        {
            get { return (MiscMenu["LowLifeES"].Cast<Slider>().CurrentValue); }
        }

        public static bool Skinhack
        {
            get { return (MiscMenu["Skinhack"].Cast<CheckBox>().CurrentValue); }
        }

        public static int SkinId
        {
            get { return (MiscMenu["SkinId"].Cast<ComboBox>().CurrentValue); }
        }

        public static bool Autolvl
        {
            get { return (MiscMenu["Autolvl"].Cast<CheckBox>().CurrentValue); }
        }

        public static int AutolvlSlider
        {
            get { return (MiscMenu["AutolvlS"].Cast<ComboBox>().CurrentValue); }
        }

        public static bool AutobuyStarters
        {
            get { return (MiscMenu["Autobuy"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool AutobuyTrinkets
        {
            get { return (MiscMenu["Autobuyt"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool AutoLantern
        {
            get { return (MiscMenu["Autolantern"].Cast<CheckBox>().CurrentValue); }
        }

        public static int AutoLanternS
        {
            get { return (MiscMenu["AutolanternHP"].Cast<Slider>().CurrentValue); }
        }
        #endregion checkvalues:Misc
        #region checkvalues:Drawing
        public static bool DrawQ
        {
            get { return (DrawingMenu["DrawQ"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool DrawE
        {
            get { return (DrawingMenu["DrawE"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool DrawCondemn
        {
            get { return (DrawingMenu["DrawCondemn"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool DrawTumble
        {
            get { return (DrawingMenu["DrawTumble"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool DrawAutoPos
        {
            get { return (DrawingMenu["DrawAutoPos"].Cast<CheckBox>().CurrentValue); }
        }

        public static bool DrawOnlyRdy
        {
            get { return (DrawingMenu["DrawOnlyReady"].Cast<CheckBox>().CurrentValue); }
        }
        #endregion checkvalues:Drawing
        #endregion checkvalues
    }
}
