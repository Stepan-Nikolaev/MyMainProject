using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Reactor : MonoBehaviour
{
    [SerializeField] private int _levelReactor;
    [SerializeField] private int _level1;
    [SerializeField] private int _level2;
    [SerializeField] private int _level3;
    [SerializeField] private int _metalsForLevel2;
    [SerializeField] private int _metalsForLevel3;
    [SerializeField] private int _maxPowerCount;
    [SerializeField] private int _spentPower;
    [SerializeField] private TMP_Text _powerIndicator;
    [SerializeField] private TMP_Text _status;
    [SerializeField] private Text _textButtonLevelUp;
    [SerializeField] private Player _player;

    private void Start()
    {
        _level1 = 2;
        _level2 = 5;
        _level3 = 7;
        _maxPowerCount = _level1;
    }

    private void Update()
    {
        _powerIndicator.text = ((_maxPowerCount - _spentPower) * 14) + " А/ч".ToString();
    }

    public void TurnOnRoom()
    {
        if (_spentPower <= _maxPowerCount)
        {
            _spentPower += 1;
        }
    }

    public void TurnOffRoom()
    {
        _spentPower -= 1;
    }

    public bool CheckCountPower()
    {
        if (_spentPower < _maxPowerCount)
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
        if (_maxPowerCount == _level1)
        {
            if (_player.GiveMetals(_metalsForLevel2))
            {
                _textButtonLevelUp.text = $"Ремонт/n {_metalsForLevel3} кг металла";
                _status.text = "Состояние: Хорошее";
                _maxPowerCount = _level2;
            }
        }
        else if (_maxPowerCount == _level2)
        {
            if (_player.GiveMetals(_metalsForLevel3))
            {
                _status.text = "Состояние: Отличное";
                _maxPowerCount = _level3;
            }
        }
    }

    public bool CheckCountPowerForSending()
    {
        if (_maxPowerCount - _spentPower >= 3)
        {
            _spentPower += 3;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SendingCansel()
    {
        _spentPower -= 3;
    }
}
