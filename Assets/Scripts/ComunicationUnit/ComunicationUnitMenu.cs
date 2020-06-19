using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ComunicationUnitMenu : MonoBehaviour
{
    [SerializeField] private ComunicationUnit _comunicationUnit;
    [SerializeField] private CanvasGroup _comunicationUnitMenu;
    [SerializeField] private Player _player;
    [SerializeField] private Button _firstSelectedButton;

    public event UnityAction<bool> CanMoveChanged;

    public void StartComunicationUnitMenu()
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
        CanMoveChanged?.Invoke(true);
    }
}
