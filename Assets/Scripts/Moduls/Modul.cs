using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modul : MonoBehaviour
{
    [SerializeField] protected string Name;
    [SerializeField] protected Image RoomDarkness;
    [SerializeField] protected PowerManagement _powerManagement;

    protected bool IsWorking;
    protected bool Power;

    public bool RoomPower => Power;
    public string RoomName => Name;

    private void Start()
    {
        IsWorking = false;
    }

    public bool GetCanUseRoom()
    {
        if (Power && !IsWorking)
        {
            return true;
        }
        else
        {
            return false;
        }
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
}
