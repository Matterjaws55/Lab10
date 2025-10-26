using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TransformSaver transformSaver;
    public PlayerController player;

    private PlayerControls controls;


    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Save.performed += ctx => SaveGame();
        controls.Player.Load.performed += ctx => LoadGame();

        transformSaver = new TransformSaver();
    }


    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    void SaveGame()
    {
        SaveData data = player.Save();
        data.targets = new List<TargetData>();

        foreach (Target target in Object.FindObjectsByType<Target>(FindObjectsSortMode.None))
        {
            data.targets.Add(new TargetData
            {
                x = target.transform.position.x,
                y = target.transform.position.y,
                z = target.transform.position.z
            });
        }

        transformSaver.SaveTransforms(data);
        ScoreSaver.SaveScore(player.score);
    }

    void LoadGame()
    {
        SaveData data = transformSaver.LoadTransforms();
        if (data != null)
        {
            player.Load(data);
            player.score = ScoreSaver.LoadScore();

            foreach (Target target in Object.FindObjectsByType<Target>(FindObjectsSortMode.None))
            {
                Object.Destroy(target.gameObject);
            }

            foreach (var t in data.targets)
            {
                
            }

            Debug.Log("Game Loaded!");
        }
    }
}