using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    // DEBUG VAR
    public const bool DEBUG_ENABLED = true;

    // SCENES LABELS
    public const string arena_scene_name    = "ARENA_SCENE";
    public const string hub_scene_name      = "HUB_SCENE";
    public const string title_scene_name    = "TITLE_SCENE";

    // PLAYER STATS CONST VALUES
    public const int LETHAL_DAMAGE  = 99;
    public const int STARTING_MONEY = 100;

    // PLAYER SAVE SLOT LABELS
    public const string bank_account    = "BANK_ACC";
    public const string death_count     = "DEATH_COUNT";

    // SHOP ITEMS 
    // UI NAMES
    public const string shopitem_name       = "Name";
    public const string shopitem_price      = "Price";
    public const string shopitem_infotext   = "InfoText";
    public const string shopitem_infoimage  = "InfoImage";


    // < name >
    public static List<string> items = new List<string>
    { "Nimbus", "Monster B", "Monster C", "Trap A", "Freedom" };

    // <name, value>
    public static Dictionary<string, int> shopItems_Price =
    new Dictionary<string, int>
    {
        { items[0], 50 },
        { items[1], 125 },
        { items[2], 210 },
        { items[3], 75 },
        { items[4], 500 }
    };

    // <name, info_text>
    public static Dictionary<string, string> shopItems_InfoText =
    new Dictionary<string, string>
    {
        { items[0], "  Flying pirhanas and avid seekers of flesh." },
        { items[1], " MONSTER B INFO TEXT " },
        { items[2], " MONSTER C INFO TEXT " },
        { items[3], " TRAP A INFO TEXT " },
        { items[4], " FREEDOM INFO TEXT " }
    };

    // <name, info_image_url>
    public static Dictionary<string, string> shopItems_InfoImage =
    new Dictionary<string, string>
    {
        { items[0], "" },
        { items[1], "" },
        { items[2], "" },
        { items[3], "" },
        { items[4], "" }
    };
    // ===================================================================================
}
