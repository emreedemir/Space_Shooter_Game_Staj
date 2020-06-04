using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public class Menu : Singleton<Menu>
{
    public UnityEvent gameExitEvent;

    public Button startButton;
    public Button exitButton;

    public void InitiliazaMenu()
    {
        RenderButtons();
    }

    void RenderButtons()
    {
        startButton.onClick.AddListener(() => StartGame());
        exitButton.onClick.AddListener(() => ExitGame());
    }

    public void MainMenuActivate(bool state)
    {
        startButton.gameObject.SetActive(state);
        exitButton.gameObject.SetActive(state);
    }

    public void GameUIActivate(bool state)
    {
       // quitButton.gameObject.SetActive(state);
    }

    void StartGame()
    {
        GameManager.Instance.SetGame();
    }

    void ExitGame()
    {
        GameManager.Instance.QuitGame();

    }
}