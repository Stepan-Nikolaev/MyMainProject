using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLevelReactor : ReactorStates
{
    private void Start()
    {
        _stateNumber = 2;
        _state = "Хорошее";
        _metalsForNextLevel = 100;
        _countRoomsPowered = 5;
    }
}
