using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PowerMenu : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CanvasGroup _powerMenu;
    [SerializeField] private Button _button1;

    public event UnityAction<bool> CanMoveChanged;

    public void Open()
    {
        _powerMenu.interactable = true;
        _powerMenu.alpha = 1;
        _button1.Select();
    }
    public void Close()
    {
        _powerMenu.interactable = false;
        _powerMenu.alpha = 0;
        CanMoveChanged?.Invoke(true);
    }
}
