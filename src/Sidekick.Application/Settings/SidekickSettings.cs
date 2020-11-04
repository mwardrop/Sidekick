using System.Collections.Generic;
using Sidekick.Domain.Settings;

namespace Sidekick.Application.Settings
{
    public class SidekickSettings : ISidekickSettings
    {
        public string Language_UI { get; set; } = "en";

        public string Language_Parser { get; set; } = null;

        public string LeagueId { get; set; } = null;

        public string LeaguesHash { get; set; } = null;

        public int League_SelectedTabIndex { get; set; } = 0;

        public WikiSetting Wiki_Preferred { get; set; } = WikiSetting.PoeWiki;

        public string Character_Name { get; set; } = null;

        public bool RetainClipboard { get; set; } = true;

        public bool CloseOverlayWithMouse { get; set; } = true;

        public bool EnableCtrlScroll { get; set; } = true;

        public bool EnablePricePrediction { get; set; } = true;

        public bool ShowSplashScreen { get; set; } = true;

        public string DangerousModsRegex { get; set; } = "reflect|regen";

        public List<string> AccessoryModifiers { get; set; } = new List<string>();
        public List<string> ArmourModifiers { get; set; } = new List<string>();
        public List<string> FlaskModifiers { get; set; } = new List<string>();
        public List<string> JewelModifiers { get; set; } = new List<string>();
        public List<string> MapModifiers { get; set; } = new List<string>();
        public List<string> WeaponModifiers { get; set; } = new List<string>();

        public string Key_CloseWindow { get; set; } = "Space";

        public string Key_CheckPrices { get; set; } = "Ctrl+D";

        public string Key_MapInfo { get; set; } = "Ctrl+X";

        public string Key_GoToHideout { get; set; } = "F5";

        public string Key_OpenWiki { get; set; } = "Alt+W";

        public string Key_FindItems { get; set; } = "Ctrl+F";

        public string Key_LeaveParty { get; set; } = "F4";

        public string Key_OpenSearch { get; set; } = "Alt+Q";

        public string Key_OpenSettings { get; set; } = "Ctrl+O";

        public string Key_OpenLeagueOverview { get; set; } = "F6";

        public string Key_ReplyToLatestWhisper { get; set; } = "Ctrl+Shift+R";

        public string Key_Exit { get; set; } = "Ctrl+Shift+X";

        public string Key_Stash_Left { get; set; } = null;

        public string Key_Stash_Right { get; set; } = null;
    }
}