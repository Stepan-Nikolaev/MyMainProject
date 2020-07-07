using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class MiningRobot : MonoBehaviour
{
    [SerializeField] private Image _miningRobotImg;
    [SerializeField] private Image _iconSpoil;
    [SerializeField] private PowerManagement _powerMenagement;
    [SerializeField] private float _timeMiningPlateau;
    [SerializeField] private float _timeMiningRocks;
    [SerializeField] private float _timeMiningCaves;
    [SerializeField] private int _countSpoilPlateau;
    [SerializeField] private int _countSpoilRocks;
    [SerializeField] private int _countSpoilCaves;
    [SerializeField] private float _time;
    [SerializeField] private TMP_Text _timer;
    [SerializeField] private CanvasGroup _timerPanel;
    [SerializeField] private float _metalsCount;

    private int _countSpoil;
    private bool _spoil;
    private Coroutine _mining;
    private Coroutine _turnMiningRobotImg;
    private bool _isMining;

    public event UnityAction<float> MetalsChanged;

    private void Start()
    {
        MetalsChanged?.Invoke(_metalsCount);
    }

    public void ContinueCorutine()
    {
        if (_mining != null)
        {
            if (_powerMenagement.UseRoom("MiningRobot"))
            {
                _mining = StartCoroutine(Mining());
            }
            else if (!_powerMenagement.UseRoom("MiningRobot"))
            {
                StopCoroutine(_mining);
            }
        }
    }

    public void PlateauChoice()
    {
        _time = _timeMiningPlateau;
        _countSpoil = _countSpoilPlateau;

        StartMining();
    }

    public void RocksChoice()
    {
        _time = _timeMiningRocks;
        _countSpoil = _countSpoilRocks;

        StartMining();
    }
    public void CavesChoice()
    {
        _time = _timeMiningCaves;
        _countSpoil = _countSpoilCaves;

        StartMining();
    }

    private void StartMining()
    {
        if (!_spoil)
        {
            _mining = StartCoroutine(Mining());
            StartMiningRobotClose();
            _isMining = true;
        }
    }

    private IEnumerator Mining()
    {
        while (_time > 0)
        {
            _timerPanel.alpha = 1;
            _timer.text = Mathf.Round(_time).ToString();
            _time -= Time.deltaTime;

            yield return null;
        }

        if (_time <= 0)
        {
            _spoil = true;
            _timerPanel.alpha = 0;
            _iconSpoil.enabled = true;
            _mining = null;
            _isMining = false;
            StartMiningRobotOpen();
        }

    }
    public void Spoil()
    {
        if (_spoil)
        {
            _metalsCount += _countSpoil;
            _spoil = false;
            _iconSpoil.enabled = false;
            MetalsChanged?.Invoke(_metalsCount);
        }
    }

    public bool IsMining()
    {
        return _isMining;
    }

    public void CheckMiningRobotImg()
    {
        if (_powerMenagement.UseRoom("MiningRobot"))
        {
            StartMiningRobotOpen();
        }
        else
        {
            StartMiningRobotClose();
        }
    }

    public void StartMiningRobotOpen()
    {
        if (_turnMiningRobotImg == null)
        {
            _turnMiningRobotImg = StartCoroutine(MiningRobotOpen());
        }
        else
        {
            StopCoroutine(_turnMiningRobotImg);
            _turnMiningRobotImg = StartCoroutine(MiningRobotOpen());
        }
    }

    public void StartMiningRobotClose()
    {
        if (_turnMiningRobotImg == null)
        {
            _turnMiningRobotImg = StartCoroutine(MiningRobotClose());
        }
        else
        {
            StopCoroutine(_turnMiningRobotImg);
            _turnMiningRobotImg = StartCoroutine(MiningRobotClose());
        }
    }

    private IEnumerator MiningRobotOpen()
    {
        while (_miningRobotImg.fillAmount != 1)
        {
            _miningRobotImg.fillAmount += Time.deltaTime;

            yield return null;
        }


    }

    private IEnumerator MiningRobotClose()
    {
        while (_miningRobotImg.fillAmount != 0)
        {
            _miningRobotImg.fillAmount -= Time.deltaTime;

            yield return null;
        }
    }

    public bool GiveMetals(int countGivenMetal)
    {
        if (countGivenMetal <= _metalsCount)
        {
            _metalsCount -= countGivenMetal;
            MetalsChanged?.Invoke(_metalsCount);

            return true;
        }
        else
        {
            return false;
        }
    }
}
