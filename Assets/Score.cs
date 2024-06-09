using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int _currentLevel;
    [SerializeField] private float[] _scoreToLevels;
    [SerializeField] private float _score;

    [SerializeField] private BonusGenerator _bonusGenerator;


    public delegate void ScoreHandler(int points);
    public event ScoreHandler OnScoreEvent;

    private void Awake()
    {
        UnityEvents.OnAddScorePoints.AddListener(AddScore);
    }

    private void Start()
    {
        UnityEvents.UpdateUIScoreBar.Invoke(_score, _scoreToLevels[_currentLevel], _currentLevel); 
    }
    public void AddScore(float points)
    {
        _score += points;
        ChangeLevel();
        UnityEvents.UpdateUIScoreBar.Invoke(_score, _scoreToLevels[_currentLevel], _currentLevel);
    }

    private void ChangeLevel()
    {
        if (_score >= _scoreToLevels[_currentLevel])
        {
            for (int i = _currentLevel; i < _scoreToLevels.Length; i++)
            {
                if(_score >= _scoreToLevels[i])
                {
                    _currentLevel++;
                    _bonusGenerator.SpawnBonus();
                }
            }
        }
    }
}
