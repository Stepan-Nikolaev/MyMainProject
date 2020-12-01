using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IndicatorsDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _hungerDisplay;
    [SerializeField] private SewageTreatment _sewageTreatment;
    [SerializeField] private TMP_Text _waterDisplay;
    [SerializeField] private Reactor _reactor;
    [SerializeField] private TMP_Text _powerDisplay;
    [SerializeField] private Greenhouse _greenhouse;
    [SerializeField] private TMP_Text _foodDisplay;
    [SerializeField] private MiningRobot _miningRobot;
    [SerializeField] private TMP_Text _metalsDisplay;
    [SerializeField] private int _minLevelIndicators;
    [SerializeField] private int _maxAmountResources;
    [SerializeField] private int _maxAmountHunger;

    private void OnEnable()
    {
        _player.HungerChanged += OnHungerChanged;
        _sewageTreatment.WaterChanged += OnWaterChanged;
        _reactor.PowerChanged += OnPowerChaged;
        _greenhouse.FoodChanger += OnFoodChanger;
        _miningRobot.MetalsChanged += OnMetalsChanger;
    }

    private void OnDisable()
    {
        _player.HungerChanged -= OnHungerChanged;
        _sewageTreatment.WaterChanged -= OnWaterChanged;
        _reactor.PowerChanged -= OnPowerChaged;
        _greenhouse.FoodChanger -= OnFoodChanger;
    }

    private void OnHungerChanged(float hunger)
    {
        _hungerDisplay.text = Mathf.Clamp(hunger, _minLevelIndicators, _maxAmountHunger).ToString() + " %";
    }

    private void OnWaterChanged(float water)
    {
        _waterDisplay.text = Mathf.Clamp(water, _minLevelIndicators, _maxAmountResources).ToString() + " литров";
    }

    private void OnPowerChaged(int power)
    {
        _powerDisplay.text = power.ToString() + " А/ч";
    }

    private void OnFoodChanger(int food)
    {
        _foodDisplay.text = Mathf.Clamp(food, _minLevelIndicators, _maxAmountResources).ToString() + " порций";
    }

    private void OnMetalsChanger(float metals)
    {
        _metalsDisplay.text = Mathf.Clamp(metals, _minLevelIndicators, _maxAmountResources).ToString() + " кг";
    }
}
