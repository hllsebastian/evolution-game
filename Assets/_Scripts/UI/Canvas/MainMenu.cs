using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject buttonsPanel;
    [SerializeField] GameObject tutorialPanel;

    public void PlayGame()
    {
        SceneManagerObject.Instance.LoadNextScene();
    }
    public void DisplayTutorial()
    {
        buttonsPanel.SetActive(false);
        tutorialPanel.SetActive(true);
    }

    public void BackToMain()
    {
        buttonsPanel.SetActive(true);
        tutorialPanel.SetActive(false);
    }
}
