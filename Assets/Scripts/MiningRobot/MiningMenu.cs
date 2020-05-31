using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiningMenu : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CanvasGroup _miningGrope;
    [SerializeField] private Button _button1;
    [SerializeField] private ProgressBar _progressBar;
    public void OpenMiningMenu()
    {
        _button1.Select();
        _miningGrope.alpha = 1;
        _miningGrope.interactable = true;
    }

    public void ChoiceLocation(int locationID)
    {
        _progressBar.StartProgressBar(locationID);

        _miningGrope.alpha = 0;
        _miningGrope.interactable = false;
    }
    public void Exit()
    {
        _miningGrope.alpha = 0;
        _miningGrope.interactable = false;
        _player.TurnMovement(true);
    }
}
