using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenhouseMenu : MonoBehaviour
{
    [SerializeField] private Greenhouse _greenhouse;
    [SerializeField] private Player _player;
    [SerializeField] private CanvasGroup _GreenhouseMenu;
    [SerializeField] private PlantMenu _plantMenu;
    [SerializeField] private Button _button1;
    public void StartGreenhouseMenu()
    {
        _button1.Select();
        _GreenhouseMenu.alpha = 1;
        _GreenhouseMenu.interactable = true;
    }

    public void Harvest()
    {
        _greenhouse.Harvest();
        _GreenhouseMenu.alpha = 0;
        _GreenhouseMenu.interactable = false;
    }

    public void CallPlantMenu()
    {
        _plantMenu.StartPlantMenu();
        _GreenhouseMenu.alpha = 0;
        _GreenhouseMenu.interactable = false;
    }

    public void Exit()
    {
        _GreenhouseMenu.alpha = 0;
        _GreenhouseMenu.interactable = false;
        _player.TurnMovement(true);
    }
}
