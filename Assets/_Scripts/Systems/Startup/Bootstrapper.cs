using UnityEngine;

/// Systems prefab is Instantiated from the Resources folder.
/// Systems prefab should contain PersistentSingleton managers
/// such as AudioManager, InputManager, etc.

public static class Bootstrapper
{
    private const string prefabName = "Bootstrap";


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {
        GameObject existingPrefab = GameObject.Find(prefabName);

        if (existingPrefab == null)
        {
            GameObject bootstrapPrefab = Resources.Load(prefabName) as GameObject;

            if (bootstrapPrefab != null)
            {
                GameObject instantiatedPrefab = Object.Instantiate(bootstrapPrefab);
                Object.DontDestroyOnLoad(instantiatedPrefab);
            }
            else
                Debug.LogError($"Prefab '{prefabName}' not found in Resources folder.");
        }
        else
            Debug.LogWarning($"Prefab '{prefabName}' already exists in the scene. Not instantiating again.");
    }
}