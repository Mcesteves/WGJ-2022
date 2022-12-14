using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string playSceneName;
    public GameObject MainMenuUI;
    public GameObject SettingsUI;
    public GameObject CreditsUI;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("Background");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene(playSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        SettingsUI.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsUI.SetActive(false);
    }
    public void OpenCredits()
    {
        CreditsUI.SetActive(true);
    }

    public void CloseCredits()
    {
        CreditsUI.SetActive(false);
    }

    public void PlayButtonSound()
    {
        AudioManager.instance.Play("Clique");
    }
}
