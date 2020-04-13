using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerMenu : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CanvasGroup _powerMenu;
    [SerializeField] private Button _button1;

    public void StartPowerMenu()
    {
        _powerMenu.interactable = true;
        _powerMenu.alpha = 1;
        _button1.Select();
    }
    public void Exit()
    {
        _powerMenu.interactable = false;
        _powerMenu.alpha = 0;
        _player.TurnMovement(true);
    }
}
