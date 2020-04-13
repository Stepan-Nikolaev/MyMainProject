using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuExit : MonoBehaviour
{
    private string _mainMenu = "MainMenu";

    [SerializeField] private Player _palyer;
    [SerializeField] private CanvasGroup _menuExit;
    [SerializeField] private Button _button1;

    public void Open()
    {
        _menuExit.alpha = 1;
        _menuExit.interactable = true;
        _button1.Select();
        Time.timeScale = 0;
    }

    public void Close()
    {
        _menuExit.alpha = 0;
        _menuExit.interactable = false;
        Time.timeScale = 1;
    }

    public void Yes()
    {
        SceneManager.LoadScene(_mainMenu);
    }

    public void No()
    {
        Close();
    }

    public bool MenuExitOpen()
    {
        return _menuExit.interactable;
    }
}
