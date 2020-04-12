using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiningMenu : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CanvasGroup _miningMenu;
    [SerializeField] private Button _button1;
    [SerializeField] private ProgressBar _progressBar;
    public void StartMiningMenu()
    {
        _button1.Select();
        _miningMenu.alpha = 1;
        _miningMenu.interactable = true;
    }

    public void ChoiceLocation(int locationID)
    {
        _progressBar.StartProgressBar(locationID);

        _miningMenu.alpha = 0;
        _miningMenu.interactable = false;
    }
    public void Exit()
    {
        _miningMenu.alpha = 0;
        _miningMenu.interactable = false;
        _player.TurnMovement(true);
    }
}
