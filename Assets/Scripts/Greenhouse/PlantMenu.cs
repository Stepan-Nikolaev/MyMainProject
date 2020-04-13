using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantMenu : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CanvasGroup _plantMenu;
    [SerializeField] private Button _button1;
    [SerializeField] private ProgressBar _progressBar;
    public void StartPlantMenu()
    {
        _button1.Select();
        _plantMenu.alpha = 1;
        _plantMenu.interactable = true;
    }

    public void ChoiceVegetables(int vegetableID)
    {
        _progressBar.StartProgressBar(vegetableID);

        _plantMenu.alpha = 0;
        _plantMenu.interactable = false;
    }
    public void Exit()
    {
        _plantMenu.alpha = 0;
        _plantMenu.interactable = false;
        _player.TurnMovement(true);
    }
}
