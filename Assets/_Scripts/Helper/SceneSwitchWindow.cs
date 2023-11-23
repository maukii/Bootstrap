using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.IO;

public class SceneSwitchWindow : EditorWindow
{
    [MenuItem("Tools/Scene Switch Window")]
    public static void Init()
    {
        SceneSwitchWindow window = GetWindow<SceneSwitchWindow>("Scene Switch Tool");
        window.minSize = new Vector2(200f, 200f);
    }

    private void OnGUI() => ScenesToButtons();

    void ScenesToButtons()
    {
        string[] sceneGuids = AssetDatabase.FindAssets("t:Scene");
        List<string> scenePaths = new List<string>();

        foreach (string guid in sceneGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            scenePaths.Add(path);
        }

        for (int i = 0; i < scenePaths.Count; i++)
        {
            string scenePath = scenePaths[i];
            string sceneName = Path.GetFileNameWithoutExtension(scenePath);
            bool pressed = GUILayout.Button($"{sceneName}", GUI.skin.button);

            if (pressed)
                SwitchToScene(scenePath);
        }
    }

    private void SwitchToScene(string scenePath)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            EditorSceneManager.OpenScene(scenePath);
    }
}