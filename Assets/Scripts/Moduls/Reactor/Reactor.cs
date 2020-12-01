using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Reactor : Modul
{
    [SerializeField] private int _countPoweredRooms;
    [SerializeField] private int _maxPowerCount;
    [SerializeField] private int _powerForComunicationUnit;
    [SerializeField] private int _powerForRoom;
    [SerializeField] private int _countPower;
    [SerializeField] private MiningRobot _miningRobot;
    [SerializeField] private ReactorStates _currentReactorState;
    [SerializeField] private PoolStates _poolStatesReactor;

    public event UnityAction<int> PowerChanged;
    public event UnityAction<ReactorStates> StateChanged;

    private void Start()
    {
        _countPower = _maxPowerCount - _countPoweredRooms * _powerForRoom;
        PowerChanged?.Invoke(_countPower);
    }

    public void TurnOnRoom()
    {
        if (_countPower > 0 && _countPower <= _maxPowerCount)
        {
            _countPower -= _powerForRoom;
            _countPoweredRooms += 1;
            PowerChanged?.Invoke(_countPower);
        }
    }

    public void TurnOffRoom()
    {
        _countPower += _powerForRoom;
        _countPoweredRooms -= 1;
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
        if (_miningRobot.GiveMetals(_currentReactorState.MetalsForNextLevel))
        {
            _currentReactorState = _poolStatesReactor.GetNextState(_currentReactorState);
            _maxPowerCount = _currentReactorState.CountRoomsPowered * _powerForRoom;
            _countPower = _maxPowerCount - _countPoweredRooms * _powerForRoom;
            PowerChanged?.Invoke(_countPower);
            StateChanged?.Invoke(_currentReactorState);
        }
    }

    public bool CheckCountPowerForSending()
    {
        if (_countPower >= _powerForComunicationUnit)
        {
            _countPower -= _powerForComunicationUnit;
            _countPoweredRooms += 3;
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
        _countPoweredRooms -= 3;
        PowerChanged?.Invoke(_countPower);
    }
}
