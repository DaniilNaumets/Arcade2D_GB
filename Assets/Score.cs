using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int _score;

    public delegate void ScoreHandler(int points);
    public event ScoreHandler OnScoreEvent;

    private void Awake()
    {
        UnityEvents.OnAddScorePoints.AddListener(AddScore);
    }
    public void AddScore(int points) => _score += points;
}
