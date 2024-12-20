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
        fish
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
            case ItemType.hp_2: return 30;
            case ItemType.hp_3: return 60;
            case ItemType.hp_4: return 90;
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
        }
    }
    public static float GetItemVariable(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.sword_1: return 1.5f;
            case ItemType.sword_2: return 2f;
            case ItemType.sword_3: return 2.5f;
            case ItemType.sword_4: return 4f;
            case ItemType.boots_1: return 165f;
            case ItemType.boots_2: return 180f;
            case ItemType.boots_3: return 210f;
            case ItemType.boots_4: return 260f;
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
            case ItemType.fish: return 5;
        }
    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.swordNull: return GameAssets.i.sword;
            case ItemType.sword_1: return GameAssets.i.sword;
            case ItemType.sword_2: return GameAssets.i.sword;
            case ItemType.sword_3: return GameAssets.i.sword;
            case ItemType.sword_4: return GameAssets.i.sword;
            case ItemType.bootsNull: return GameAssets.i.speed;
            case ItemType.boots_1: return GameAssets.i.speed;
            case ItemType.boots_2: return GameAssets.i.speed;
            case ItemType.boots_3: return GameAssets.i.speed;
            case ItemType.boots_4: return GameAssets.i.speed;
            case ItemType.hpNull: return GameAssets.i.heart;
            case ItemType.hp_1: return GameAssets.i.heart;
            case ItemType.hp_2: return GameAssets.i.heart;
            case ItemType.hp_3: return GameAssets.i.heart;
            case ItemType.hp_4: return GameAssets.i.heart;
            case ItemType.milkNull: return GameAssets.i.milk;
            case ItemType.milk_1: return GameAssets.i.milk;
            case ItemType.milk_2: return GameAssets.i.milk;
            case ItemType.milk_3: return GameAssets.i.milk;
            case ItemType.milk_4: return GameAssets.i.milk;
            case ItemType.staminaNull: return GameAssets.i.stamina;
            case ItemType.stamina_1: return GameAssets.i.stamina;
            case ItemType.stamina_2: return GameAssets.i.stamina;
            case ItemType.stamina_3: return GameAssets.i.stamina;
            case ItemType.stamina_4: return GameAssets.i.stamina;
            case ItemType.fishNull: return GameAssets.i.fish;
            case ItemType.fish: return GameAssets.i.fish;
        }
    }
}
