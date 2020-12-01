using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolStates : MonoBehaviour
{
    [SerializeField] private List<ReactorStates> _poolStates;

    public ReactorStates GetNextState(ReactorStates currentState)
    {
        if (currentState.StateNumber <= _poolStates.Count)
        {
            return _poolStates[currentState.StateNumber];
        }
        else
        {
            return currentState;
        }
    }
}
