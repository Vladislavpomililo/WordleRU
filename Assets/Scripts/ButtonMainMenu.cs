using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject backToMainMenu;
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject startGame;

    public void OpenMenuStart()
    {
        startMenu.SetActive(true);
        startGame.SetActive(false);
    }

    public void ExitMenuStart()
    {
        startGame.SetActive(true);
        startMenu.SetActive(false);
    }

    public void HelpMenuOpen()
    {
        helpMenu.SetActive(true);
    }

    public void HelpMenuExit()
    {
        helpMenu.SetActive(false);
    }

    public void StartGameCell()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
    }

    public void SettingsExit()
    {
        settingsMenu.SetActive(false);
    }

    public void CancelBackToMain()
    {
        backToMainMenu.SetActive(false);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BackToMainMenuOption()
    {
        backToMainMenu.SetActive(true);
    }
}
