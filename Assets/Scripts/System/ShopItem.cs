using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public enum ItemType
    {
        Hp,
        Pistol,
        Rifle,
        Shotgun,
        Armor,
    }

    public static int GetCost(ItemType itemType){
        switch(itemType)
        {
            default:
            case ItemType.Hp:       return 5;
            case ItemType.Pistol:   return 10;
            case ItemType.Rifle:    return 13;
            case ItemType.Shotgun:  return 16;
            case ItemType.Armor:    return 10;
        }
    }

    public static Sprite GetSprite(ItemType itemType){
        switch(itemType)
        {
            default:
            case ItemType.Hp:       return GameAssets.i.s_Hp;
            case ItemType.Pistol:   return GameAssets.i.s_Pistol;
            case ItemType.Rifle:    return GameAssets.i.s_Rifle;
            case ItemType.Shotgun:  return GameAssets.i.s_Shotgun;
            case ItemType.Armor:    return GameAssets.i.s_Armor;
        }
    }
}
