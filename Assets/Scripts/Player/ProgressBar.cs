using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private MiningRobot _miningRobot;
    [SerializeField] private Reactor _reactor;
    [SerializeField] private Player _player;
    [SerializeField] private CanvasGroup _progressBar;
    [SerializeField] private Greenhouse _greenhouse;
    [SerializeField] private Image _progressImage;
    [SerializeField] private TMP_Text _progressText;

    [SerializeField] private float _time;
    [SerializeField] private float _period;

    public event UnityAction<bool> CanMoveChanged;

    public void StartProgressBar(int actID)
    {
        _time = 0;
        CanMoveChanged?.Invoke(false);
        StartCoroutine(Progress(actID));
    }

    private IEnumerator Progress(int actID)
    {
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
            switch (actID)
            {
                case 1:
                    _greenhouse.TomatoesChoice();
                    break;
                case 2:
                    _greenhouse.CornChoice();
                    break;
                case 3:
                    _greenhouse.PotatoesChoice();
                    break;
                case 4:
                    _player.Eaten();
                    break;
                case 5:
                    _reactor.LevelUp();
                    break;
                case 6:
                    _miningRobot.PlateauChoice();
                    break;
                case 7:
                    _miningRobot.RocksChoice();
                    break;
                case 8:
                    _miningRobot.CavesChoice();
                    break;
            }

            CanMoveChanged?.Invoke(true);
            _progressBar.alpha = 0;
        }
    }
}
