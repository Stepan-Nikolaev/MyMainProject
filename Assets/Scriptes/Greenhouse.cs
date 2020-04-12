using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Greenhouse : MonoBehaviour
{
    [SerializeField] private SewageTreatment _sewageTreatment;
    [SerializeField] private PowerManagement _powerMenagement;
    [SerializeField] private Image _iconHarvestCorn;
    [SerializeField] private Image _iconHarvestPotato;
    [SerializeField] private Image _iconHarvestTomato;
    [SerializeField] private Player _player;
    [SerializeField] private float _timeGrowthTomatoes;
    [SerializeField] private float _timeGrowthCorn;
    [SerializeField] private float _timeGrowthPotatoes;
    [SerializeField] private float _timeWatering;
    [SerializeField] private float _periodWatering;
    [SerializeField] private float _countWatering;
    [SerializeField] private int _countPortionsTomatoes;
    [SerializeField] private int _countPortionsCorn;
    [SerializeField] private int _countPortionsPotatoes;
    [SerializeField] private float _time;
    [SerializeField] private TMP_Text _timer;
    [SerializeField] private CanvasGroup _timerPanel;

    private int _countPortions;
    private bool _harvest;
    private Image _iconHarvest;
    private Coroutine _growth;
    private bool _isGrowing;

    public void TomatoesChoice()
    {
        _iconHarvest = _iconHarvestTomato;
        _time = _timeGrowthTomatoes;
        _countPortions = _countPortionsTomatoes;

        StartGrowth();
    }

    public void CornChoice()
    {
        _iconHarvest = _iconHarvestCorn;
        _time = _timeGrowthCorn;
        _countPortions = _countPortionsCorn;

        StartGrowth();
    }
    public void PotatoesChoice()
    {
        _iconHarvest = _iconHarvestPotato;
        _time = _timeGrowthPotatoes;
        _countPortions = _countPortionsPotatoes;

        StartGrowth();
    }

    public void ContinueCorutine()
    {
        if (_growth != null)
        {
            if (_powerMenagement.UseRoom(1))
            {
                _growth = StartCoroutine(Growth());
            }
            else if (!_powerMenagement.UseRoom(1))
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
            _isGrowing = true;
        }
        else
        {
            _player.TurnMovement(true);
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

        if (_time <= 0)
        {
            _harvest = true;
            _timerPanel.alpha = 0;
            _iconHarvest.enabled = true;
            _growth = null;
            _isGrowing = false;
        }

    }

    public void Harvest()
    {
        if (_harvest)
        {
            _player.TakeHarvest(_countPortions);
            _harvest = false;
            _iconHarvest.enabled = false;
        }
        else
        {
            _player.TurnMovement(true);
        }
    }

    public bool IsGrowing()
    {
        return _isGrowing;
    }
}
