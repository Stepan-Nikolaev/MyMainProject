using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlantMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup _plantMenu;
    [SerializeField] private Button _firstSelectedButton;
    [SerializeField] private ProgressBar _progressBar;

    public void StartPlantMenu()
    {
        _firstSelectedButton.Select();
        _plantMenu.alpha = 1;
        _plantMenu.interactable = true;
    }

    public void ChoiceVegetables(string nameAction)
    {
        _progressBar.StartProgressBar(nameAction);

        _plantMenu.alpha = 0;
        _plantMenu.interactable = false;
    }
    public void Exit()
    {
        _plantMenu.alpha = 0;
        _plantMenu.interactable = false;
    }
}
