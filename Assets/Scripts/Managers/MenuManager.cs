using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialPanel;
    public void StartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public void GetTutorial(bool open)
    {
        if (!open)
            _tutorialPanel.SetActive(true);
        else
            _tutorialPanel.SetActive(false);
    }

    public void Quit() => Application.Quit();
}
