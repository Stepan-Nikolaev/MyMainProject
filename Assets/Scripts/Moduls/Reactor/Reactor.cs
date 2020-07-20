using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Reactor : Modul
{
    [SerializeField] private int _level1;
    [SerializeField] private int _level2;
    [SerializeField] private int _level3;
    [SerializeField] private int _metalsForLevel2;
    [SerializeField] private int _metalsForLevel3;
    [SerializeField] private int _maxPowerCount;
    [SerializeField] private int _powerForComunicationUnit;
    [SerializeField] private int _powerForRoom;
    [SerializeField] private int _countPower;
    [SerializeField] private TMP_Text _status;
    [SerializeField] private Text _textButtonLevelUp;
    [SerializeField] private MiningRobot _miningRobot;

    public event UnityAction<int> PowerChanged;

    private void Start()
    {
        _level1 = 2;
        _level2 = 5;
        _level3 = 7;
        _maxPowerCount = _level1 * _powerForRoom;
        PowerChanged?.Invoke(_countPower);
    }

    public void TurnOnRoom()
    {
        if (_countPower > 0 && _countPower <= _maxPowerCount)
        {
            _countPower -= _powerForRoom;
            PowerChanged?.Invoke(_countPower);
        }
    }

    public void TurnOffRoom()
    {
        _countPower += _powerForRoom;
        PowerChanged?.Invoke(_countPower);
    }

    public bool CheckCountPower()
    {
        if (_countPower > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void LevelUp()
    {
        if (_maxPowerCount == (_level1 * _powerForRoom))
        {
            if (_miningRobot.GiveMetals(_metalsForLevel2))
            {
                _textButtonLevelUp.text = $"Ремонт/n {_metalsForLevel3} кг металла";
                _status.text = "Состояние: Хорошее";
                _maxPowerCount = _level2 * _powerForRoom;
                _countPower = _maxPowerCount - (_level1 * _powerForRoom - _countPower);
                PowerChanged?.Invoke(_countPower);
            }
        }
        else if (_maxPowerCount == (_level2 * _powerForRoom))
        {
            if (_miningRobot.GiveMetals(_metalsForLevel3))
            {
                _status.text = "Состояние: Отличное";
                _maxPowerCount = _level3 * _powerForRoom;
                _countPower = _maxPowerCount - (_level2 * _powerForRoom - _countPower);
                PowerChanged?.Invoke(_countPower);
            }
        }
    }

    public bool CheckCountPowerForSending()
    {
        if (_countPower >= _powerForComunicationUnit)
        {
            _countPower -= _powerForComunicationUnit;
            PowerChanged?.Invoke(_countPower);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SendingCansel()
    {
        _countPower += _powerForComunicationUnit;
        PowerChanged?.Invoke(_countPower);
    }
}
