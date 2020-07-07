using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuExit : MonoBehaviour
{
    [SerializeField] private CanvasGroup _menuExit;
    [SerializeField] private Button _firstSelectedButton;

    public void Open()
    {
        _menuExit.alpha = 1;
        _menuExit.interactable = true;
        _firstSelectedButton.Select();
        Time.timeScale = 0;
    }

    public void Close()
    {
        _menuExit.alpha = 0;
        _menuExit.interactable = false;
        Time.timeScale = 1;
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ReturnToGame()
    {
        Close();
    }

    public bool MenuExitOpen()
    {
        return _menuExit.interactable;
    }
}
