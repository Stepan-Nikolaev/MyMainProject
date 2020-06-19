using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ReactorMenu : MonoBehaviour
{
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private Player _player;
    [SerializeField] private CanvasGroup _reactorMenu;
    [SerializeField] private PowerMenu _PowerMenu;
    [SerializeField] private Button _button1;

    public event UnityAction<bool> CanMoveChanged;

    public void StartReactorMenu()
    {
        _button1.Select();
        _reactorMenu.alpha = 1;
        _reactorMenu.interactable = true;
    }

    public void LevelUp()
    {
        _progressBar.StartProgressBar(5);
        _reactorMenu.alpha = 0;
        _reactorMenu.interactable = false;
    }

    public void CallPowerMenu()
    {
        _PowerMenu.StartPowerMenu();

        _reactorMenu.alpha = 0;
        _reactorMenu.interactable = false;
    }

    public void Exit()
    {
        _reactorMenu.alpha = 0;
        _reactorMenu.interactable = false;
        CanMoveChanged?.Invoke(true);
    }
}
