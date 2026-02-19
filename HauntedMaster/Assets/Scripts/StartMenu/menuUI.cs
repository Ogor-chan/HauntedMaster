using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuUI : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject showCredits;


    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    
    public void ShowCredits()
    {
        startMenu.SetActive(false);
        showCredits.SetActive(true);
    }

    public void BackToMenu()
    {
        startMenu.SetActive(true);
        showCredits.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
