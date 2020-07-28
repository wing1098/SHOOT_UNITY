using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunSwitching : MonoBehaviour
{
    public static int selectedWeapon = 0;

    public Image[] gunsUi;

    void Start()
    {
        SelectedWeapon();
    }

    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
                gunsUi[selectedWeapon++].color = new Color(255, 255, 255, .3f);

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
            
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            //all gun ui color change to unselected color
            gunsUi[0].color = new Color(255, 255, 255, .3f);
            gunsUi[1].color = new Color(255, 255, 255, .3f);
            gunsUi[2].color = new Color(255, 255, 255, .3f);

            //selected gun ui color change to white
            SelectedWeapon();

        }
    }

    void SelectedWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);

                //selected gun change to white color
                gunsUi[i].color = new Color(255, 255, 255, 255);

            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
