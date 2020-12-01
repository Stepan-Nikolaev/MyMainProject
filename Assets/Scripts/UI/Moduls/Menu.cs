using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class Menu : MonoBehaviour
{
    protected CanvasGroup _windowMenu;

    private void Start()
    {
        _windowMenu = GetComponent<CanvasGroup>();
    }

    public void Open()
    {
        _windowMenu.alpha = 1;
        _windowMenu.interactable = true;
        _windowMenu.blocksRaycasts = true;
    }

    public void Close()
    {
        _windowMenu.alpha = 0;
        _windowMenu.interactable = false;
        _windowMenu.blocksRaycasts = false;
    }
}
