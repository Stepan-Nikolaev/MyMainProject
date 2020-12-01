using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modul : MonoBehaviour
{
    [SerializeField] protected string Name;
    [SerializeField] protected Image RoomDarkness;
    [SerializeField] protected PowerDistributor _powerDistributor;

    protected bool IsWorking;
    protected bool Power;

    public bool RoomPower => Power;
    public string RoomName => Name;
    public bool GetCanUseRoom
    {
        get
        {
            return Power && !IsWorking;
        }
    }

    private void Start()
    {
        IsWorking = false;
    }

    public void  TurnOnPower()
    {
        Power = true;
        RoomDarkness.enabled = false;
    }

    public void TurnOffPower()
    {
        Power = false;
        RoomDarkness.enabled = true;
    }

    public void PlayerAction(string nameAction)
    {
        
    }
}
