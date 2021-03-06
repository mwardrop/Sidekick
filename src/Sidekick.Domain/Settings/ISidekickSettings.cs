using System.Collections.Generic;

namespace Sidekick.Domain.Settings
{
    public interface ISidekickSettings
    {
        string Language_Parser { get; }
        string Language_UI { get; }

        string LeagueId { get; }
        string LeaguesHash { get; }

        string Character_Name { get; }
        bool RetainClipboard { get; }
        string Key_FindItems { get; }
        string Key_OpenSettings { get; }
        bool ShowSplashScreen { get; }

        bool Price_CloseWithMouse { get; }
        string Price_Key_Check { get; }
        string Price_Key_OpenSearch { get; }
        string Price_Key_Close { get; }
        bool Price_Prediction_Enable { get; }
        List<string> Price_Mods_Accessory { get; }
        List<string> Price_Mods_Armour { get; }
        List<string> Price_Mods_Flask { get; }
        List<string> Price_Mods_Jewel { get; }
        List<string> Price_Mods_Map { get; }
        List<string> Price_Mods_Weapon { get; }

        bool Map_CloseWithMouse { get; }
        string Map_Key_Close { get; }
        string Map_Key_Check { get; }
        string Map_Dangerous_Regex { get; }

        string Cheatsheets_Key_Open { get; }
        int Cheatsheets_SelectedIndex { get; }

        string Chat_Key_Exit { get; }
        string Chat_Key_Hideout { get; }
        string Chat_Key_LeaveParty { get; }
        string Chat_Key_ReplyToLastWhisper { get; }
        List<CustomChatSetting> Chat_CustomCommands { get; }

        string Stash_Key_Left { get; }
        string Stash_Key_Right { get; }
        bool Stash_EnableCtrlScroll { get; }

        string Wiki_Key_Open { get; }
        WikiSetting Wiki_Preferred { get; }
    }
}
