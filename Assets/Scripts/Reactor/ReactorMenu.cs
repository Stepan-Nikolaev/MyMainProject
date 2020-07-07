using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ReactorMenu : MonoBehaviour
{
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private CanvasGroup _reactorMenu;
    [SerializeField] private PowerMenu _PowerMenu;
    [SerializeField] private Button _firstSelectedButton;

    public void OpenReactorMenu()
    {
        _firstSelectedButton.Select();
        _reactorMenu.alpha = 1;
        _reactorMenu.interactable = true;
    }

    public void LevelUp()
    {
        _progressBar.StartProgressBar("LevelUp");
        _reactorMenu.alpha = 0;
        _reactorMenu.interactable = false;
    }

    public void CallPowerMenu()
    {
        _PowerMenu.Open();

        _reactorMenu.alpha = 0;
        _reactorMenu.interactable = false;
    }

    public void Close()
    {
        _reactorMenu.alpha = 0;
        _reactorMenu.interactable = false;
    }
}
