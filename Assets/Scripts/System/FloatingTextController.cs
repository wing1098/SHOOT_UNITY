//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FloatingTextController : MonoBehaviour
//{
//    private static FloatingText popupText;

//    private static GameObject canvas;

//    public static void Initialize()
//    {
//        canvas = GameObject.Find("Canvas");
//        if(!popupText)
//            popupText = Resources.Load<FloatingText>("Prefabs/PopUp Parent");
//    }

//    public static void CreateFloatingText(string text, Transform transform)
//    {
//        FloatingText instance = Instantiate(popupText);

//        Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, .5f)));
       
//        instance.transform.SetParent(canvas.transform, false);
//        instance.transform.position = screenPosition;
//        instance.SetText(text);
//    }
//}
