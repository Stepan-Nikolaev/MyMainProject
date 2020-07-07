using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PowerMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup _powerMenu;
    [SerializeField] private Button _firstSelectedButton;

    public void Open()
    {
        _powerMenu.interactable = true;
        _powerMenu.alpha = 1;
        _firstSelectedButton.Select();
    }
    public void Close()
    {
        _powerMenu.interactable = false;
        _powerMenu.alpha = 0;
    }
}
