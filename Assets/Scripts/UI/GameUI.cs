using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup _alertPanel;
    [SerializeField] private CanvasGroup _gameOver;
    [SerializeField] private CanvasGroup _victory;
    [SerializeField] private CanvasGroup _welcome;
    [SerializeField] private MenuExit _menuExit;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _playerInput.CloseWelcomeWindow += OnCloseWelcomeWindow;
        _player.PlayerDie += OnPlayerDie;
        _player.PlayerHungry += OnPlayerHungry;
    }

    private void OnDisable()
    {
        _playerInput.CloseWelcomeWindow -= OnCloseWelcomeWindow;
        _player.PlayerDie -= OnPlayerDie;
        _player.PlayerHungry -= OnPlayerHungry;
    }

    private void OnCloseWelcomeWindow()
    {
        CloseWelcomeWindow();
    }

    private void OnPlayerDie()
    {
        GameOver();
    }

    private void OnPlayerHungry(bool playerHungry)
    {
        if (playerHungry)
            ActivateAlertPanel();
        else
            DeactivateAlertPanel();
    }

    private void Start()
    {
        _welcome.alpha = 1;
        _welcome.interactable = true;
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        _animator.SetBool("IsDead", true);
        _gameOver.alpha = 1;
        _gameOver.interactable = true;
        Time.timeScale = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Victory()
    {
        _victory.alpha = 1;
        _victory.interactable = true;
        Time.timeScale = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void CloseWelcomeWindow()
    {
        if (_welcome.interactable)
        {
            _welcome.alpha = 0;
            _welcome.interactable = false;
            Time.timeScale = 1;
        }
    }

    public void ActivateAlertPanel()
    {
        _alertPanel.alpha = 1;
    }

    public void DeactivateAlertPanel()
    {
        _alertPanel.alpha = 0;
    }
}
