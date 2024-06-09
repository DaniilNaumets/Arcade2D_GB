using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    [SerializeField] private Image _scoreBar;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _levelText;
    [SerializeField] private Score _currentScore;

    private void Awake()
    {
        UnityEvents.UpdateUIScoreBar.AddListener(UpdateScoreBar);
    }

    public void UpdateScoreBar(float curScore, float needScore, int curLevel)
    {
        _scoreBar.fillAmount = curScore / needScore;
        _scoreText.text = $"{curScore} / {needScore}";
        _levelText.text = (curLevel + 1).ToString();

        StopAllCoroutines();
    }  
}
