using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>();

    public ItemData GetItemByName(string itemName)
    {
        foreach (ItemData item in items)
        {
            if (item != null && item.itemName == itemName)
                return item;
        }

        return null;
    }
}
