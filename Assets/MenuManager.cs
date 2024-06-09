using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialPanel;
    public void StartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public void GetTutorial() => _tutorialPanel.SetActive(true);

    public void Quit() => Application.Quit();
}
