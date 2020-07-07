using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MiningMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup _miningGrope;
    [SerializeField] private Button _firstSelectedButton;
    [SerializeField] private ProgressBar _progressBar;

    public void OpenMiningMenu()
    {
        _firstSelectedButton.Select();
        _miningGrope.alpha = 1;
        _miningGrope.interactable = true;
    }

    public void ChoiceLocation(string nameAction)
    {
        _progressBar.StartProgressBar(nameAction);

        _miningGrope.alpha = 0;
        _miningGrope.interactable = false;
    }
    public void Exit()
    {
        _miningGrope.alpha = 0;
        _miningGrope.interactable = false;
    }
}
