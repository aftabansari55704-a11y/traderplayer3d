using UnityEngine;

public enum ItemType
{
    Food,
    Clothes,
    Electronics,
    Tools
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Metro Trader/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public ItemType itemType;

    public int basePrice = 100;
}
