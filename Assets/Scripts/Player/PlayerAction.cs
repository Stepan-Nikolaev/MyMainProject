using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private Greenhouse _greenhouse;
    [SerializeField] private Reactor _reactor;
    [SerializeField] private MiningRobot _miningRobot;
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private Player _player;
    private Modul _modul;
    private string NameAction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Modul modul))
        {
            _modul = modul;
        }
    }

    public void StartAction(string nameAction)
    {
        NameAction = nameAction;
        _progressBar.StartProgressBar();
    }

    public void FinishAction()
    {
        switch (NameAction)
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
            case "MineOnRocks":
            case "MineOnCaves":
                _miningRobot.StartMining(NameAction);
                break;
            case "Harvest":
                _greenhouse.Harvest();
                break;
            case "Spoil":
                _miningRobot.Spoil();
                break;
        }
    }
}
