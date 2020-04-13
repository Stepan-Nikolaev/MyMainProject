using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SewageTreatment : MonoBehaviour
{
    [SerializeField] private PowerManagement _powerMeneger;
    [SerializeField] private TMP_Text _waterIndicator;
    [SerializeField] private float _waterCount;
    [SerializeField] private float _time;
    [SerializeField] private float _period;
    [SerializeField] private float _periodWaterConsumption;
    [SerializeField] private float _timeWaterConsumption;

    private void Update()
    {
        if (_powerMeneger.UseRoom(5))
        {
            if (_time <= 0)
            {
                _waterCount += 2;
                _time = _period;
            }
            else
            {
                _time -= Time.deltaTime;
            }
        }

        _waterIndicator.text = _waterCount.ToString() + " литров";
    }

    public void Drink(float countDrinkingWater)
    {
        _waterCount -= countDrinkingWater;
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
