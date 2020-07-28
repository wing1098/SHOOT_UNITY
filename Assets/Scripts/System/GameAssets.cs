using System.Collections;
using UnityEngine;
using System.Reflection;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i{
        get{
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    public Sprite s_Hp;
    public Sprite s_Pistol;
    public Sprite s_Rifle;
    public Sprite s_Shotgun;
    public Sprite s_Armor;

}
