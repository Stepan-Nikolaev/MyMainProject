using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ComunicationUnit : Modul
{
    [SerializeField] private float _time;
    [SerializeField] private float _timeSending;
    [SerializeField] private Reactor _reactor;
    [SerializeField] private TMP_Text _timer;
    [SerializeField] private CanvasGroup _timerPanel;
    [SerializeField] private GameUI _gameUI;
    private Coroutine _sending;

    public void StartSending()
    {
        if (_reactor.CheckCountPowerForSending())
        {
            _time = _timeSending;
            _sending = StartCoroutine(Sending());
            IsWorking = true;
        }
    }

    public void ContinueCorutine()
    {
        if (_sending != null)
        {
            StopCoroutine(_sending);
            _reactor.SendingCansel();
            _timerPanel.alpha = 0;
            _time = _timeSending;
            _sending = null;
        }
    }

    private IEnumerator Sending()
    {
        while (_time > 0)
        {
            _timerPanel.alpha = 1;
            _timer.text = Mathf.Round(_time).ToString();
            _time -= Time.deltaTime;

            yield return null;
        }

        _timerPanel.alpha = 0;
        IsWorking = false;
        _reactor.SendingCansel();
        _gameUI.Victory();
    }
}
