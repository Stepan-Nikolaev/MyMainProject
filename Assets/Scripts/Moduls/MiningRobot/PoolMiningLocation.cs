using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMiningLocation : MonoBehaviour
{
    [SerializeField] private List<MiningLocation> _miningLocations;

    public MiningLocation GetCurrentMiningLocation(string nameAction)
    {
        for(int i = 0; i < _miningLocations.Count; i++)
        {
            if (_miningLocations[i].NameAction == nameAction)
            {
                return _miningLocations[i];
            }
        }

        return null;
    }
}
