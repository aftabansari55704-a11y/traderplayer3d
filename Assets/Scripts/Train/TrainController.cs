using UnityEngine;

public class TrainController : MonoBehaviour
{
    public int travelCost = 50;

    public bool TravelToStation(Station destination)
    {
        if (destination == null)
            return false;

        GameManager gameManager = GameManager.Instance;

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found.");
            return false;
        }

        if (!gameManager.CanAfford(travelCost))
        {
            Debug.Log("Not enough money for the train ticket.");
            return false;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player not found.");
            return false;
        }

        if (destination.playerSpawnPoint == null)
        {
            Debug.LogError("Destination spawn point is missing.");
            return false;
        }

        gameManager.SpendMoney(travelCost);

        player.transform.position =
            destination.playerSpawnPoint.position;

        Debug.Log("Travelled to " + destination.stationName);

        return true;
    }
}
