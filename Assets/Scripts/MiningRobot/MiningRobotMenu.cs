using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MiningRobotMenu : MonoBehaviour
{
    [SerializeField] private MiningRobot _miningRobot;
    [SerializeField] private CanvasGroup _miningRobotMenu;
    [SerializeField] private MiningMenu _miningMenu;
    [SerializeField] private Button _firstSelectedButton;

    public void OpenMiningRobotMenu()
    {
        _firstSelectedButton.Select();
        _miningRobotMenu.alpha = 1;
        _miningRobotMenu.interactable = true;
    }

    public void Spoil()
    {
        _miningRobotMenu.alpha = 0;
        _miningRobotMenu.interactable = false;
    }

    public void CallMiningMenu()
    {
        _miningMenu.OpenMiningMenu();
        _miningRobotMenu.alpha = 0;
        _miningRobotMenu.interactable = false;
    }

    public void Exit()
    {
        _miningRobotMenu.alpha = 0;
        _miningRobotMenu.interactable = false;
    }
}
