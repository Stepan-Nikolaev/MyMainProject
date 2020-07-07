using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private MenuExit _menuExit;
    [SerializeField] private PowerManagement _powerManagement;
    [SerializeField] private Greenhouse _greenhouse;
    [SerializeField] private GreenhouseMenu _greenhouseMenu;
    [SerializeField] private ReactorMenu _reactorMenu;
    [SerializeField] private MiningRobot _miningRobot;
    [SerializeField] private MiningRobotMenu _miningRobotMenu;
    [SerializeField] private ComunicationUnitMenu _comunicationUnitMenu;
    [SerializeField] private GameUI _gameUI;
    private Player _player;
    private Animator _animator;

    public event UnityAction<bool> CanMoveChanged;

    private void Start()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _animator.SetBool("BackIdle", true);
            _progressBar.StartProgressBar("Eaten");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_menuExit.MenuExitOpen())
            {
                _menuExit.Close();
                _player.TakeCanMove(true);
            }
            else
            {
                _menuExit.Open();
                _player.TakeCanMove(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _gameUI.Welcome();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Greenhouse greenhouse))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_powerManagement.UseRoom("Greenhouse") && !_greenhouse.IsGrowing())
                {
                    _animator.SetBool("LeftWolk", false);
                    _animator.SetBool("RightWolk", false);
                    _greenhouseMenu.OpenGreenhouseMenu();
                    _player.TakeCanMove(false);
                }
            }
        }

        if (collision.TryGetComponent(out Reactor reactor))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_powerManagement.UseRoom("PowerStation"))
                {
                    _animator.SetBool("LeftWolk", false);
                    _animator.SetBool("RightWolk", false);
                    _reactorMenu.OpenReactorMenu();
                    _player.TakeCanMove(false);
                }
            }
        }

        if (collision.TryGetComponent(out MiningRobot miningRobot))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_powerManagement.UseRoom("MiningRobot") && !_miningRobot.IsMining())
                {
                    _animator.SetBool("LeftWolk", false);
                    _animator.SetBool("RightWolk", false);
                    _miningRobotMenu.OpenMiningRobotMenu();
                    _player.TakeCanMove(false);
                }
            }
        }

        if (collision.TryGetComponent(out ComunicationUnit comunicationUnit))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_powerManagement.UseRoom("ComunicationUnit"))
                {
                    _animator.SetBool("LeftWolk", false);
                    _animator.SetBool("RightWolk", false);
                    _comunicationUnitMenu.OpenComunicationUnitMenu();
                    _player.TakeCanMove(false);
                }
            }
        }
    }
}
