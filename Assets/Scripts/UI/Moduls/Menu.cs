using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private CanvasGroup CanvasMenu;

    private void Start()
    {
        CanvasMenu = GetComponent<CanvasGroup>();
    }

    public void Open()
    {
        CanvasMenu.alpha = 1;
        CanvasMenu.interactable = true;
        CanvasMenu.blocksRaycasts = true;
    }

    public void Close()
    {
        CanvasMenu.alpha = 0;
        CanvasMenu.interactable = false;
        CanvasMenu.blocksRaycasts = false;
    }
}
