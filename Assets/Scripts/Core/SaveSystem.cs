using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame()
    {
        if (GameManager.Instance == null)
            return;

        PlayerPrefs.SetInt("Money", GameManager.Instance.money);
        PlayerPrefs.SetInt("Level", GameManager.Instance.level);
        PlayerPrefs.SetInt("Experience", GameManager.Instance.experience);

        PlayerPrefs.Save();

        Debug.Log("Game Saved");
    }

    public static void LoadGame()
    {
        if (GameManager.Instance == null)
            return;

        if (!PlayerPrefs.HasKey("Money"))
            return;

        GameManager.Instance.money =
            PlayerPrefs.GetInt("Money");

        GameManager.Instance.level =
            PlayerPrefs.GetInt("Level");

        GameManager.Instance.experience =
            PlayerPrefs.GetInt("Experience");

        Debug.Log("Game Loaded");
    }
}
