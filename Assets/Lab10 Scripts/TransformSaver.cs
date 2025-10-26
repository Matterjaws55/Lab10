using System.Collections.Generic;
using System.IO;
using UnityEditor.Overlays;
using UnityEngine;

public class TransformSaver
{
    private string jsonPath;

    public TransformSaver()
    {
        jsonPath = Application.persistentDataPath + "/transforms.json";
    }

    public void SaveTransforms(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(jsonPath, json);
        Debug.Log("Saved Transforms to: " + jsonPath);
    }

    public SaveData LoadTransforms()
    {
        if (File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);
            return JsonUtility.FromJson<SaveData>(json);
        }

        Debug.LogWarning("No transform file found.");
        return null;
    }
}