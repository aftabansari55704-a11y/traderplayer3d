using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text levelText;
    public TMP_Text inventoryText;

    public Inventory inventory;

    private void Update()
    {
        if (GameManager.Instance == null)
            return;

        if (moneyText != null)
        {
            moneyText.text =
                "Money: ₹" + GameManager.Instance.money;
        }

        if (levelText != null)
        {
            levelText.text =
                "Level: " + GameManager.Instance.level;
        }

        if (inventoryText != null && inventory != null)
        {
            inventoryText.text =
                "Inventory: " +
                inventory.GetTotalQuantity() +
                "/" +
                GameManager.Instance.inventoryCapacity;
        }
    }
}
