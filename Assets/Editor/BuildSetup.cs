#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class BuildSetup
{
    private const string ScenePath = "Assets/Scenes/MainScene.unity";

    [MenuItem("Metro Trader/Setup Build")]
    public static void SetupBuild()
    {
        CreateMainScene();
    }

    public static void CreateMainScene()
    {
        Scene scene = EditorSceneManager.NewScene(
            NewSceneSetup.EmptyScene,
            NewSceneMode.Single
        );

        // ---------- Ground ----------
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.name = "Ground";
        ground.transform.position = Vector3.zero;
        ground.transform.localScale = new Vector3(5f, 1f, 5f);

        // ---------- Player ----------
        GameObject player = new GameObject("Player");
        player.tag = "Player";
        player.transform.position = new Vector3(0f, 1f, 0f);

        CharacterController controller =
            player.AddComponent<CharacterController>();

        controller.height = 2f;
        controller.radius = 0.4f;

        player.AddComponent<PlayerController>();
        player.AddComponent<Inventory>();

        // ---------- Game Manager ----------
        GameObject gameManager =
            new GameObject("GameManager");

        gameManager.AddComponent<GameManager>();

        // ---------- Trading ----------
        GameObject tradingSystem =
            new GameObject("TradingSystem");

        tradingSystem.AddComponent<TradingSystem>();
        tradingSystem.AddComponent<ItemDatabase>();

        // ---------- Station ----------
        GameObject stationObject =
            new GameObject("Central Station");

        stationObject.transform.position =
            new Vector3(0f, 0f, 8f);

        Station station =
            stationObject.AddComponent<Station>();

        station.stationName = "Central Station";

        GameObject spawnPoint =
            new GameObject("PlayerSpawnPoint");

        spawnPoint.transform.SetParent(
            stationObject.transform
        );

        spawnPoint.transform.localPosition =
            new Vector3(0f, 1f, -2f);

        station.playerSpawnPoint =
            spawnPoint.transform;

        // ---------- Train ----------
        GameObject trainSystem =
            new GameObject("TrainSystem");

        trainSystem.AddComponent<TrainController>();

        // ---------- Camera ----------
        GameObject cameraObject =
            new GameObject("Main Camera");

        Camera camera =
            cameraObject.AddComponent<Camera>();

        cameraObject.tag = "MainCamera";

        cameraObject.transform.position =
            new Vector3(0f, 8f, -10f);

        cameraObject.transform.rotation =
            Quaternion.Euler(30f, 0f, 0f);

        // ---------- Light ----------
        GameObject lightObject =
            new GameObject("Directional Light");

        Light light =
            lightObject.AddComponent<Light>();

        light.type = LightType.Directional;
        light.intensity = 1.2f;

        lightObject.transform.rotation =
            Quaternion.Euler(50f, -30f, 0f);

        // ---------- UI ----------
        GameObject uiObject =
            new GameObject("UIManager");

        uiObject.AddComponent<UIManager>();

        // ---------- Save Scene ----------
        EditorSceneManager.SaveScene(
            scene,
            ScenePath
        );

        Debug.Log(
            "Metro Trader 3D MainScene created successfully."
        );
    }

    public static void PrepareForBuild()
    {
        CreateMainScene();

        EditorBuildSettings.scenes =
            new[]
            {
                new EditorBuildSettingsScene(
                    ScenePath,
                    true
                )
            };

        Debug.Log(
            "Metro Trader 3D build scene prepared."
        );
    }
}

#endif
