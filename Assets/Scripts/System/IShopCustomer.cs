using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopCustomer
{
    void BouthItem(ShopItem.ItemType itemType);

    bool TrySpendGoldAmount(int spendGoldAmount);
}
