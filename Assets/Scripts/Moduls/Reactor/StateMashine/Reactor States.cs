using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorStates : MonoBehaviour
{
    protected int _stateNumber;
    protected string _state;
    protected int _metalsForNextLevel;
    protected int _countRoomsPowered;

    public int StateNumber
    {
        get
        {
            return _stateNumber;
        }
    }

    public string State
    {
        get
        {
            return _state;
        }
    }

    public int MetalsForNextLevel
    {
        get
        {
            return _metalsForNextLevel;
        }
    }

    public int CountRoomsPowered
    {
        get
        {
            return _countRoomsPowered;
        }
    }

    public void Blablabla()
    {

    }
}
