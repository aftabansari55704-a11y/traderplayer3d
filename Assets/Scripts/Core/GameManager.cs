using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Money")]
    public int money = 10000;

    [Header("Player Progress")]
    public int level = 1;
    public int experience = 0;

    [Header("Inventory")]
    public int inventoryCapacity = 20;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool CanAfford(int amount)
    {
        return money >= amount;
    }

    public bool SpendMoney(int amount)
    {
        if (amount < 0 || money < amount)
            return false;

        money -= amount;
        return true;
    }

    public void AddMoney(int amount)
    {
        if (amount > 0)
            money += amount;
    }

    public void AddExperience(int amount)
    {
        if (amount <= 0)
            return;

        experience += amount;

        int requiredXP = level * 100;

        while (experience >= requiredXP)
        {
            experience -= requiredXP;
            level++;

            Debug.Log("Level Up! New Level: " + level);

            requiredXP = level * 100;
        }
    }
}
