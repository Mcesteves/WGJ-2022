using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenuManager : MonoBehaviour
{
    public GameObject SettingsUI;
    public GameObject PauseUI;
    public GameObject PauseCanvas;
    void Start()
    {
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        PauseCanvas.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseCanvas.SetActive(true);
    }

    public void OpenSettings()
    {
        PauseUI.SetActive(false);
        SettingsUI.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsUI.SetActive(false);
        PauseUI.SetActive(true);
        
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }

    public void PlayButtonSound()
    {
        AudioManager.instance.Play("Clique");
    }
}
