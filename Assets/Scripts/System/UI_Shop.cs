using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{
    public Transform container;
    public Transform shopItemTemplate;
    private IShopCustomer shopCustomer;


    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");

        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        CreateItemButton(ShopItem.ItemType.Hp, ShopItem.GetSprite(ShopItem.ItemType.Hp), "HEALTH", ShopItem.GetCost(ShopItem.ItemType.Hp), 0);
        CreateItemButton(ShopItem.ItemType.Pistol, ShopItem.GetSprite(ShopItem.ItemType.Pistol), "PISTOL" , ShopItem.GetCost(ShopItem.ItemType.Pistol), 1);
        CreateItemButton(ShopItem.ItemType.Rifle, ShopItem.GetSprite(ShopItem.ItemType.Rifle), "RIFLE"  , ShopItem.GetCost(ShopItem.ItemType.Rifle), 2);
        CreateItemButton(ShopItem.ItemType.Shotgun, ShopItem.GetSprite(ShopItem.ItemType.Shotgun), "SHOTGUN", ShopItem.GetCost(ShopItem.ItemType.Shotgun), 3);

        Hide();
    }


    private void CreateItemButton(ShopItem.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 90f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("nameText").GetComponent<Text>().text = itemName.ToString();
        shopItemTransform.Find("costText").GetComponent<Text>().text = "$" + itemCost.ToString();

        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;

        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () =>
        {
            //Clicked on shop item button
            TryBuyItem(itemType);
        };
    }

    private void TryBuyItem(ShopItem.ItemType itemType)
    {
       if(shopCustomer.TrySpendGoldAmount(ShopItem.GetCost(itemType)))
        {
            //can afforf cost
            shopCustomer.BouthItem(itemType);
        }
    }

    public void Show(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
