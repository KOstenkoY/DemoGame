using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Window MainMenuWindow;
    [SerializeField]
    Window pauseWindow;
    [SerializeField]
    GameObject hudVisual;

    private void Start()
    { 
        Time.timeScale = 0;
        MainMenuWindow.Open();
        MainMenuWindow.OnClose += StartGame;
        pauseWindow.OnOpen += Pause;
        pauseWindow.OnClose += UnPause;
    }

    private void StartGame()
    {
        MainMenuWindow.OnClose -= StartGame;
        Time.timeScale = 1;
        hudVisual.SetActive(true);
    }

    private void Pause()
    {
        hudVisual.SetActive(false);
        Time.timeScale = 0;
    }

    private void UnPause()
    {
        Time.timeScale = 1;
        hudVisual.SetActive(true);
    }
}
