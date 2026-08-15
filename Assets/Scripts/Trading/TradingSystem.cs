using UnityEngine;

public class TradingSystem : MonoBehaviour
{
    public static TradingSystem Instance;

    private Inventory playerInventory;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerInventory = FindFirstObjectByType<Inventory>();

        if (playerInventory == null)
        {
            Debug.LogError("Inventory not found.");
        }
    }

    public bool BuyItem(Station station, ItemData item, int quantity)
    {
        if (station == null || item == null || quantity <= 0)
            return false;

        if (playerInventory == null)
            return false;

        int price = station.GetBuyPrice(item);

        if (price <= 0)
        {
            Debug.Log("Item is not available at this station.");
            return false;
        }

        if (!playerInventory.HasSpace(quantity))
        {
            Debug.Log("Inventory is full.");
            return false;
        }

        int totalCost = price * quantity;

        if (!GameManager.Instance.CanAfford(totalCost))
        {
            Debug.Log("Not enough money.");
            return false;
        }

        GameManager.Instance.SpendMoney(totalCost);
        playerInventory.AddItem(item, quantity);

        GameManager.Instance.AddExperience(quantity * 2);

        Debug.Log(
            "Bought " + quantity + " " +
            item.itemName + " for ₹" + totalCost
        );

        return true;
    }

    public bool SellItem(Station station, ItemData item, int quantity)
    {
        if (station == null || item == null || quantity <= 0)
            return false;

        if (playerInventory == null)
            return false;

        int price = station.GetSellPrice(item);

        if (price <= 0)
        {
            Debug.Log("This item cannot be sold here.");
            return false;
        }

        if (playerInventory.GetQuantity(item) < quantity)
        {
            Debug.Log("Not enough items in inventory.");
            return false;
        }

        int totalEarned = price * quantity;

        if (!playerInventory.RemoveItem(item, quantity))
            return false;

        GameManager.Instance.AddMoney(totalEarned);
        GameManager.Instance.AddExperience(quantity * 3);

        Debug.Log(
            "Sold " + quantity + " " +
            item.itemName + " for ₹" + totalEarned
        );

        return true;
    }
}
