using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoManager : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public int currentGun;
    public float currentAmmo;

    void Update()
    {
        if (GunSwitching.selectedWeapon == 0)
            ammoText.text = (int)PistolController.currentAmmo + "/" + (int)PistolController.maxAmmo;
                if(PistolController.currentAmmo == 0)
                    ammoText.text =  "Reloading";            

        if (GunSwitching.selectedWeapon == 1)
            ammoText.text = (int)RifleController.currentAmmo + "/" + (int)RifleController.maxAmmo;
                if (RifleController.currentAmmo == 0)
                    ammoText.text = "Reloading";

        if (GunSwitching.selectedWeapon == 2)
            ammoText.text = (int)ShotGunController.currentAmmo + "/" + (int)ShotGunController.maxAmmo;
                if (ShotGunController.currentAmmo == 0)
                    ammoText.text = "Reloading";
    }
}
