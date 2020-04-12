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

    public void StartMenuExit()
    {
        _menuExit.alpha = 1;
        _menuExit.interactable = true;
        _button1.Select();
    }

    public void Yes()
    {
        SceneManager.LoadScene(_mainMenu);
    }

    public void No()
    {
        _menuExit.alpha = 0;
        _menuExit.interactable = false;
    }
}
