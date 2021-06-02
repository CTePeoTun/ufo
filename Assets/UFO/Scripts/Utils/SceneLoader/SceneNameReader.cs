#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;
using System.IO;
using Cysharp.Threading.Tasks;

public class SceneNameReader : MonoBehaviour
{

    private static List<string> Scenes = new List<string>();

    [MenuItem("Settings/SceneLoader/Get All Scenes In Build")]
    private static void ReadAllSceneNameInBuild()
    {
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            Scenes.Add(Path.GetFileNameWithoutExtension(scene.path));
        } 
        CreateEnum();
    }

    [MenuItem("Settings/SceneLoader/Get Active Scenes In Build")]
    private static void ReadActiveScenesInBuild()
    {
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                Scenes.Add(Path.GetFileNameWithoutExtension(scene.path));
            }
        }
        CreateEnum();
    }

    private static void CreateEnum()
    {
        string content = "public enum SceneName \n{\n   ";
        foreach (var scene in Scenes)
        {
            content += scene;
            if (scene != Scenes.Last())
            {
                content += ", ";
            }
        }
        content += "\n}";
        File.WriteAllText(GetScriptsDirectory() + "/SceneName.cs", content);
        AssetDatabase.Refresh();
    }

    private static string GetScriptsDirectory()
    {
        string[] res = Directory.GetFiles(Application.dataPath, typeof(SceneNameReader).ToString() + ".cs", SearchOption.AllDirectories);
        if (res.Length == 0)
        {
            Debug.LogError("error message ....");
            return null;
        }
        return Path.GetDirectoryName(res[0]);
    }




}
#endif
