using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdLevelReactor : ReactorStates
{
    private void Start()
    {
        _stateNumber = 3;
        _state = "Отличное";
        _metalsForNextLevel = 0;
        _countRoomsPowered = 7;
    }
}
