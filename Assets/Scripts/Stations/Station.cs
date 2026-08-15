using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StationItemPrice
{
    public ItemData item;
    public int buyPrice;
    public int sellPrice;
}

public class Station : MonoBehaviour
{
    public string stationName;

    public List<StationItemPrice> items =
        new List<StationItemPrice>();

    public Transform playerSpawnPoint;

    public int GetBuyPrice(ItemData item)
    {
        foreach (StationItemPrice data in items)
        {
            if (data != null && data.item == item)
                return data.buyPrice;
        }

        return -1;
    }

    public int GetSellPrice(ItemData item)
    {
        foreach (StationItemPrice data in items)
        {
            if (data != null && data.item == item)
                return data.sellPrice;
        }

        return -1;
    }
}
