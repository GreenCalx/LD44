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
    public const string splash_screen_name  = "SplashScreen";

    // PLAYER STATS CONST VALUES
    public const int LETHAL_DAMAGE  = 99;
    public const int STARTING_MONEY = 10;

    // PLAYER SAVE SLOT LABELS
    public const string bank_account    = "BANK_ACC";
    public const string death_count     = "DEATH_COUNT";

    // TWEAK VAR FOR MONSTER SPAWNER
    public const float intervalBetweenMonsterSpawnersSpawn  = 5f;
    public const float maxMonsterSpawnersSpawn              = 8;

    public const float intervalBetweenTrapSpawn             = 5f;
    public const float sawTrapSpawnChance                   = 0.3f;
    public const float maxTrapSpawn = 5;


    // -------------------------------------------------------------
    // SHOP ITEMS 
    // UI NAMES
    public const string shopitem_name       = "Name";
    public const string shopitem_price      = "Price";
    public const string shopitem_infotext   = "InfoText";
    public const string shopitem_infoimage  = "InfoImage";


    // < name >
    public static List<string> items = new List<string>
    { "Nimbus", "CosmicHazard", "SoulReaver", "SawTrap", "Freedom" };

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
        { items[1], " A Block of flesh with thousand mouths and eyes. " },
        { items[2], " A soul sucker monster. " },
        { items[3], " A saw trap that will please the crowd by spreading guts everywhere. " },
        { items[4], " Free your soul from this cosmic hell. It's time to unite with your body on earth again." }
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

    // -------------------------------------------------------------
    // UNLOCKABLES
    public static Dictionary<string, string> unlocked_items =
    new Dictionary<string, string>
    {
        { items[0], "UNLOCKED______A" },
        { items[1], "UNLOCKED______B" },
        { items[2], "UNLOCKED______C" },
        { items[3], "UNLOCKED______D" },
        { items[4], "UNLOCKED______E" }
    };

    // MONSTERS
    public static List<string> monsters = new List<string>
        { "Slime", items[0], items[1], items[2] };

    // TRAPS
    public static List<string> traps = new List<string>
        { items[3] };
}
