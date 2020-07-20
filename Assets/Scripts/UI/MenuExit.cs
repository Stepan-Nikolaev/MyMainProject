using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuExit : MonoBehaviour
{
    [SerializeField] private CanvasGroup _menuExit;
    [SerializeField] private Button _firstSelectedButton;
    [SerializeField] private PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput.EscPressed += OnEscPressed;
    }

    private void OnDisable()
    {
        _playerInput.EscPressed -= OnEscPressed;
    }

    private void OnEscPressed()
    {
        if (GetStateMenuExit())
        {
            Close();
            Time.timeScale = 1;
        }
        else
        {
            Open();
            Time.timeScale = 0;
        }
    }

    public void Open()
    {
        _menuExit.alpha = 1;
        _menuExit.interactable = true;
        _menuExit.blocksRaycasts = true;
        _firstSelectedButton.Select();
        Time.timeScale = 0;
    }

    public void Close()
    {
        _menuExit.alpha = 0;
        _menuExit.interactable = false;
        _menuExit.blocksRaycasts = false;
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

    private bool GetStateMenuExit()
    {
        return _menuExit.interactable;
    }
}
