using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningLocation : MonoBehaviour
{
    [SerializeField] protected string _nameAction;
    [SerializeField] protected int _timeMining;
    [SerializeField] protected int _countSpoil;

    public string NameAction
    {
        get
        {
            return _nameAction;
        }
    }
    public int TimeMining
    {
        get
        {
            return _timeMining;
        }
    }
    public int CountSpoil
    {
        get
        {
            return _countSpoil;
        }
    }
}
