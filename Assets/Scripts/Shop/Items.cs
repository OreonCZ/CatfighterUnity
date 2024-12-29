using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items
{
    public enum ItemType
    {
        swordNull,
        sword_1,
        sword_2,
        sword_3,
        sword_4,
        bootsNull,
        boots_1,
        boots_2,
        boots_3,
        boots_4,
        hpNull,
        hp_1,
        hp_2,
        hp_3,
        hp_4,
        milkNull,
        milk_1,
        milk_2,
        milk_3,
        milk_4,
        staminaNull,
        stamina_1,
        stamina_2,
        stamina_3,
        stamina_4,
        fishNull,
        fish,
        gearNull,
        gear,
        ballNull,
        ball
    }

    public static ItemType? GetNextItem(ItemType currentItem)
    {
        if (currentItem == ItemType.sword_1) return ItemType.sword_2;
        if (currentItem == ItemType.sword_2) return ItemType.sword_3;
        if (currentItem == ItemType.sword_3) return ItemType.sword_4;

        if (currentItem == ItemType.hp_1) return ItemType.hp_2;
        if (currentItem == ItemType.hp_2) return ItemType.hp_3;
        if (currentItem == ItemType.hp_3) return ItemType.hp_4;

        if (currentItem == ItemType.boots_1) return ItemType.boots_2;
        if (currentItem == ItemType.boots_2) return ItemType.boots_3;
        if (currentItem == ItemType.boots_3) return ItemType.boots_4;

        if (currentItem == ItemType.milk_1) return ItemType.milk_2;
        if (currentItem == ItemType.milk_2) return ItemType.milk_3;
        if (currentItem == ItemType.milk_3) return ItemType.milk_4;

        if (currentItem == ItemType.stamina_1) return ItemType.stamina_2;
        if (currentItem == ItemType.stamina_2) return ItemType.stamina_3;
        if (currentItem == ItemType.stamina_3) return ItemType.stamina_4;

        return null; // No further upgrades
    }

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.swordNull: return 0;
            case ItemType.sword_1: return 10;
            case ItemType.sword_2: return 50;
            case ItemType.sword_3: return 150;
            case ItemType.sword_4: return 400;
            case ItemType.bootsNull: return 0;
            case ItemType.boots_1: return 30;
            case ItemType.boots_2: return 80;
            case ItemType.boots_3: return 140;
            case ItemType.boots_4: return 400;
            case ItemType.hpNull: return 0;
            case ItemType.hp_1: return 10;
            case ItemType.hp_2: return 50;
            case ItemType.hp_3: return 150;
            case ItemType.hp_4: return 400;
            case ItemType.milkNull: return 0;
            case ItemType.milk_1: return 10;
            case ItemType.milk_2: return 20;
            case ItemType.milk_3: return 40;
            case ItemType.milk_4: return 60;
            case ItemType.staminaNull: return 0;
            case ItemType.stamina_1: return 40;
            case ItemType.stamina_2: return 80;
            case ItemType.stamina_3: return 160;
            case ItemType.stamina_4: return 320;
            case ItemType.fishNull: return 0;
            case ItemType.fish: return 100;
            case ItemType.gear: return 50;
            case ItemType.ball: return 500;
        }
    }

    public static string GetItemName(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.swordNull: return "Default sword";
            case ItemType.sword_1: return "Sword LVL1";
            case ItemType.sword_2: return "Sword LVL2";
            case ItemType.sword_3: return "Sword LVL3";
            case ItemType.sword_4: return "BFS";
            case ItemType.bootsNull: return "Default boots";
            case ItemType.boots_1: return "Boots LVL1";
            case ItemType.boots_2: return "Boots LVL2";
            case ItemType.boots_3: return "Boots LVL3";
            case ItemType.boots_4: return "Speedy boots";
            case ItemType.hpNull: return "Default armor";
            case ItemType.hp_1: return "Armor LVL1";
            case ItemType.hp_2: return "Armor LVL2";
            case ItemType.hp_3: return "Armor LVL3";
            case ItemType.hp_4: return "Tank Meta";
            case ItemType.milkNull: return "Milk";
            case ItemType.milk_1: return "Milk milk";
            case ItemType.milk_2: return "Milk milk milk";
            case ItemType.milk_3: return "Milk milk milk milk";
            case ItemType.milk_4: return "Mmmmmmmmmmm";
            case ItemType.staminaNull: return "Default stamina";
            case ItemType.stamina_1: return "Catnip";
            case ItemType.stamina_2: return "Catnip dust";
            case ItemType.stamina_3: return "Catnip ball";
            case ItemType.stamina_4: return "Catnip cigaro";
            case ItemType.fishNull: return "Default fish";
            case ItemType.fish: return "Fish";
            case ItemType.gearNull: return "Default gear";
            case ItemType.gear: return "Suba diving gear";
            case ItemType.ballNull: return "Default ball";
            case ItemType.ball: return "Default ball";
        }
    }

    public static int GetItemLoc(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.swordNull: return 0;
            case ItemType.sword_1: return 0;
            case ItemType.sword_2: return 0;
            case ItemType.sword_3: return 0;
            case ItemType.sword_4: return 0;
            case ItemType.bootsNull: return 1;
            case ItemType.boots_1: return 1;
            case ItemType.boots_2: return 1;
            case ItemType.boots_3: return 1;
            case ItemType.boots_4: return 1;
            case ItemType.hpNull: return 2;
            case ItemType.hp_1: return 2;
            case ItemType.hp_2: return 2;
            case ItemType.hp_3: return 2;
            case ItemType.hp_4: return 2;
            case ItemType.milkNull: return 3;
            case ItemType.milk_1: return 3;
            case ItemType.milk_2: return 3;
            case ItemType.milk_3: return 3;
            case ItemType.milk_4: return 3;
            case ItemType.staminaNull: return 4;
            case ItemType.stamina_1: return 4;
            case ItemType.stamina_2: return 4;
            case ItemType.stamina_3: return 4;
            case ItemType.stamina_4: return 4;
            case ItemType.fishNull: return 5;
            case ItemType.fish: return 5;
            case ItemType.gearNull: return 6;
            case ItemType.gear: return 6;
            case ItemType.ballNull: return 7;
            case ItemType.ball: return 7;
        }
    }
    public static float GetItemVariable(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.sword_1: return 1f;
            case ItemType.sword_2: return 2f;
            case ItemType.sword_3: return 3f;
            case ItemType.sword_4: return 4f;
            case ItemType.boots_1: return 10f;
            case ItemType.boots_2: return 30f;
            case ItemType.boots_3: return 50f;
            case ItemType.boots_4: return 80f;
            case ItemType.hp_1: return 10f;
            case ItemType.hp_2: return 12f;
            case ItemType.hp_3: return 15f;
            case ItemType.hp_4: return 20f;
            case ItemType.milk_1: return 3f;
            case ItemType.milk_2: return 4f;
            case ItemType.milk_3: return 5f;
            case ItemType.milk_4: return 6f;
            case ItemType.stamina_1: return 70f;
            case ItemType.stamina_2: return 90f;
            case ItemType.stamina_3: return 110f;
            case ItemType.stamina_4: return 130f;
            case ItemType.fish: return 0f;
            case ItemType.gear: return 0f;
            case ItemType.ball: return 0f;
        }
    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.swordNull: return GameAssets.i.sword1;
            case ItemType.sword_1: return GameAssets.i.sword1;
            case ItemType.sword_2: return GameAssets.i.sword2;
            case ItemType.sword_3: return GameAssets.i.sword3;
            case ItemType.sword_4: return GameAssets.i.sword4;
            case ItemType.bootsNull: return GameAssets.i.speed1;
            case ItemType.boots_1: return GameAssets.i.speed1;
            case ItemType.boots_2: return GameAssets.i.speed2;
            case ItemType.boots_3: return GameAssets.i.speed3;
            case ItemType.boots_4: return GameAssets.i.speed4;
            case ItemType.hpNull: return GameAssets.i.heart1;
            case ItemType.hp_1: return GameAssets.i.heart1;
            case ItemType.hp_2: return GameAssets.i.heart2;
            case ItemType.hp_3: return GameAssets.i.heart3;
            case ItemType.hp_4: return GameAssets.i.heart4;
            case ItemType.milkNull: return GameAssets.i.milk1;
            case ItemType.milk_1: return GameAssets.i.milk1;
            case ItemType.milk_2: return GameAssets.i.milk2;
            case ItemType.milk_3: return GameAssets.i.milk3;
            case ItemType.milk_4: return GameAssets.i.milk4;
            case ItemType.staminaNull: return GameAssets.i.stamina1;
            case ItemType.stamina_1: return GameAssets.i.stamina1;
            case ItemType.stamina_2: return GameAssets.i.stamina2;
            case ItemType.stamina_3: return GameAssets.i.stamina3;
            case ItemType.stamina_4: return GameAssets.i.stamina4;
            case ItemType.fishNull: return GameAssets.i.fish;
            case ItemType.fish: return GameAssets.i.fish;
            case ItemType.gear: return GameAssets.i.gear;
            case ItemType.ball: return GameAssets.i.ball;
        }
    }
}
