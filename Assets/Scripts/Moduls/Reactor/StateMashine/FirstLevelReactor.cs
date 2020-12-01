using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelReactor : ReactorStates
{
    void Start()
    {
        _stateNumber = 1;
        _state = "Плохоe";
        _metalsForNextLevel = 40;
        _countRoomsPowered = 2;
    }
}
