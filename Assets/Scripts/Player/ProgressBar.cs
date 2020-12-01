using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private PlayerAction _playerAction;
    [SerializeField] private CanvasGroup _progressBar;
    [SerializeField] private Player _player;
    [SerializeField] private Image _progressImage;
    [SerializeField] private TMP_Text _progressText;
    [SerializeField] private float _time;
    [SerializeField] private float _period;

    public void StartProgressBar()
    {
        _time = 0;
        StartCoroutine(PerformingAction());
    }

    private IEnumerator PerformingAction()
    {
        _player.TakeInfoAboutPlayer(false);

        while (_time <= _period)
        {
            _progressBar.alpha = 1;
            _time += Time.deltaTime;
            _progressText.text = Mathf.Round(_time * 20).ToString() + "%";
            _progressImage.fillAmount = (_time / 5);

            yield return null;
        }

        if (_time > _period)
        {
            _playerAction.FinishAction();

            _player.TakeInfoAboutPlayer(true);
            _progressBar.alpha = 0;
        }
    }
}
