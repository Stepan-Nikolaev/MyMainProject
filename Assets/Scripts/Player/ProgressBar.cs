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

    public void StartProgressBar(string nameAction)
    {
        _time = 0;
        StartCoroutine(Progress(nameAction));
    }

    private IEnumerator Progress(string nameAction)
    {
        _player.TakeCanMove(false);

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
            switch (nameAction)
            {
                case "PlantTomatoes":
                    _greenhouse.TomatoesChoice();
                    break;
                case "PlantCorn":
                    _greenhouse.CornChoice();
                    break;
                case "PlantPotatoes":
                    _greenhouse.PotatoesChoice();
                    break;
                case "Eaten":
                    _player.Eaten();
                    break;
                case "LevelUp":
                    _reactor.LevelUp();
                    break;
                case "MineOnPlateau":
                    _miningRobot.PlateauChoice();
                    break;
                case "MineOnRocks":
                    _miningRobot.RocksChoice();
                    break;
                case "MineOnCaves":
                    _miningRobot.CavesChoice();
                    break;
            }

            _player.TakeCanMove(true);
            _progressBar.alpha = 0;
        }
    }
}
