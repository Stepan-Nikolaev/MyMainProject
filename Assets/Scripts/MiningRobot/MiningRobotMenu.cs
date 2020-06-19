using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MiningRobotMenu : MonoBehaviour
{
    [SerializeField] private MiningRobot _miningRobot;
    [SerializeField] private Player _player;
    [SerializeField] private CanvasGroup _miningRobotMenu;
    [SerializeField] private MiningMenu _miningMenu;
    [SerializeField] private Button _button1;

    public event UnityAction<bool> CanMoveChanged;

    public void StartMiningRobotMenu()
    {
        _button1.Select();
        _miningRobotMenu.alpha = 1;
        _miningRobotMenu.interactable = true;
    }

    public void Spoil()
    {
        _miningRobot.Spoil();
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
        CanMoveChanged?.Invoke(true);
    }
}
