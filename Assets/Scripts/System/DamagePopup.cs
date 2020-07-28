//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class DamagePopup : MonoBehaviour
//{

//    public TextMeshPro textMesh;

//    private void Awake()
//    {
        
//    }
//    public static DamagePopup Create()
//    {
//        Transform damagePopupTransform = Instantiate(HurtPlayer.DmgPopup, Vector3.zero, Quaternion.identity);
//        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
//        damagePopup.Setup(300);

//        return damagePopup;
//    }

//    public void Setup(int damgeAmount)
//    {
//        textMesh.SetText(damgeAmount.ToString());
//    }
//}
