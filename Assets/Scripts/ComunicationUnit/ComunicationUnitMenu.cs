using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ComunicationUnitMenu : MonoBehaviour
{
    [SerializeField] private ComunicationUnit _comunicationUnit;
    [SerializeField] private CanvasGroup _comunicationUnitMenu;
    [SerializeField] private Button _firstSelectedButton;

    public void OpenComunicationUnitMenu()
    {
        _firstSelectedButton.Select();
        _comunicationUnitMenu.alpha = 1;
        _comunicationUnitMenu.interactable = true;
    }

    public void StartSending()
    {
        _comunicationUnit.StartSending();
        _comunicationUnitMenu.alpha = 0;
        _comunicationUnitMenu.interactable = false;
    }

    public void Exit()
    {
        _comunicationUnitMenu.alpha = 0;
        _comunicationUnitMenu.interactable = false;
    }
}
