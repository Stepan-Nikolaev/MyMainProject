using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class SewageTreatment : Modul
{
    [SerializeField] private float _waterCount;
    [SerializeField] private float _time;
    [SerializeField] private float _period;
    [SerializeField] private float _periodWaterConsumption;
    [SerializeField] private float _timeWaterConsumption;

    public event UnityAction<float> WaterChanged;

    private void Start()
    {
        WaterChanged?.Invoke(_waterCount);
    }

    private void Update()
    {
        if (GetCanUseRoom())
        {
            if (_time <= 0)
            {
                _waterCount += 2;
                _time = _period;
                WaterChanged?.Invoke(_waterCount);
            }
            else
            {
                _time -= Time.deltaTime;
            }
        }
    }

    public void Drink(float countDrinkingWater)
    {
        _waterCount -= countDrinkingWater;
        WaterChanged?.Invoke(_waterCount);
    }

    public bool CheckCountWater()
    {
        if (_waterCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
