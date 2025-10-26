using UnityEngine;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour, IObserver
{
    public static ScoreManager Instance;
    private int currentScore = 0;

    private void Awake() => Instance = this;

    public void UpdateScore(int amount)
    {
        currentScore += amount;
        Debug.Log("Score: " + currentScore);
    }

    public void AddScore(int points) => UpdateScore(points);
}