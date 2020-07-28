using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private UI_Shop shop;
    [SerializeField] private DoorAnims nextDoor;
    static bool waveEnd;

    private void OnTriggerEnter(Collider other)
    {
        IShopCustomer shopCustomer = other.GetComponent<IShopCustomer>();
        if(shopCustomer != null)
        {
            nextDoor.OpenDoor();
            shop.Show(shopCustomer);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IShopCustomer shopCustomer = other.GetComponent<IShopCustomer>();
        if (shopCustomer != null)
        {
            shop.Hide();
        }
    }
}
