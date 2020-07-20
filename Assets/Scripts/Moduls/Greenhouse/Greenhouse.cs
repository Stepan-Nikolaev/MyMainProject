using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Greenhouse : Modul
{
    [SerializeField] private Tomato _tomatoIcon;
    [SerializeField] private Corn _cornIcon;
    [SerializeField] private Potato _potatoIcon;
    [SerializeField] private SewageTreatment _sewageTreatment;
    [SerializeField] private float _timeWatering;
    [SerializeField] private float _periodWatering;
    [SerializeField] private float _countWatering;
    [SerializeField] private float _time;
    [SerializeField] private int _foodCount;
    [SerializeField] private TMP_Text _timer;
    [SerializeField] private CanvasGroup _timerPanel;

    private int _countPortions;
    private bool _harvest;
    private Coroutine _growth;
    private Crops _chosenVegetable;

    public event UnityAction<int> FoodChanger;

    private void Start()
    {
        FoodChanger?.Invoke(_foodCount);
    }

    public void TomatoesChoice()
    {
        _chosenVegetable = _tomatoIcon;
        _time = _tomatoIcon.GetGrowthTime();
        _countPortions = _tomatoIcon.GetCountPortions();

        StartGrowth();
    }

    public void CornChoice()
    {
        _chosenVegetable = _cornIcon;
        _time = _cornIcon.GetGrowthTime();
        _countPortions = _cornIcon.GetCountPortions();

        StartGrowth();
    }
    public void PotatoesChoice()
    {
        _chosenVegetable = _potatoIcon;
        _time = _potatoIcon.GetGrowthTime();
        _countPortions = _potatoIcon.GetCountPortions();

        StartGrowth();
    }

    public void ContinueCorutine()
    {
        if (_growth != null)
        {
            if (Power)
            {
                _growth = StartCoroutine(Growth());
            }
            else
            {
                StopCoroutine(_growth);
            }
        }
    }
    private void StartGrowth()
    {
        if (!_harvest)
        {
            _growth = StartCoroutine(Growth());
            IsWorking = true;
        }
    }

    private IEnumerator Growth()
    {
        while (_time > 0)
        {
            _timerPanel.alpha = 1;
            _timer.text = Mathf.Round(_time).ToString();
            _time -= Time.deltaTime;

            if (_timeWatering <= 0)
            {
                _sewageTreatment.Drink(_countWatering);
                _timeWatering = _periodWatering;
            }
            else
            {
                _timeWatering -= Time.deltaTime;
            }

            yield return null;
        }

        _timerPanel.alpha = 0;
        _chosenVegetable.TurnIcon();
        _growth = null;
        IsWorking = false;
        _harvest = true;
    }

    public void Harvest()
    {
        if (_harvest)
        {
            _foodCount += _countPortions;
            _harvest = false;
            _chosenVegetable.TurnIcon();
            FoodChanger?.Invoke(_foodCount);
        }
    }

    public bool TakeFood()
    {
        if (_foodCount > 0)
        {
            _foodCount -= 1;
            FoodChanger?.Invoke(_foodCount);

            return true;
        }
        else
        {
            return false;
        }
    }
}
