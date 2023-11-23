using UnityEngine;

/// Systems prefab is Instantiated from the Resources folder.
/// Systems prefab should contain PersistentSingleton managers
/// such as AudioManager, InputManager, etc.

public static class Bootstrapper
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute() => Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load("Bootstrap")));
}