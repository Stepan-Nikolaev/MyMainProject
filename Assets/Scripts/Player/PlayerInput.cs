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
    private Animator _animator;

    public event UnityAction<bool> CanMoveChanged;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            //Кушать, у прогресс бара - 4
            _animator.SetBool("BackIdle", true);
            _progressBar.StartProgressBar(4);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_menuExit.MenuExitOpen())
            {
                _menuExit.Close();
            }
            else
            {
                _menuExit.Open();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _gameUI.Welcome();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Greenhouse"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_powerManagement.UseRoom(1) && !_greenhouse.IsGrowing())
                {
                    _animator.SetBool("LeftWolk", false);
                    _animator.SetBool("RightWolk", false);
                    CanMoveChanged?.Invoke(false);
                    _greenhouseMenu.StartGreenhouseMenu();
                }
            }
        }

        if (collision.gameObject.CompareTag("PowerStation"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_powerManagement.UseRoom(2))
                {
                    _animator.SetBool("LeftWolk", false);
                    _animator.SetBool("RightWolk", false);
                    CanMoveChanged?.Invoke(false);
                    _reactorMenu.StartReactorMenu();
                }
            }
        }

        if (collision.gameObject.CompareTag("MiningRobot"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_powerManagement.UseRoom(3) && !_miningRobot.IsMining())
                {
                    _animator.SetBool("LeftWolk", false);
                    _animator.SetBool("RightWolk", false);
                    CanMoveChanged?.Invoke(false);
                    _miningRobotMenu.StartMiningRobotMenu();
                }
            }
        }

        if (collision.gameObject.CompareTag("CommunicationUnit"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_powerManagement.UseRoom(7))
                {
                    _animator.SetBool("LeftWolk", false);
                    _animator.SetBool("RightWolk", false);
                    CanMoveChanged?.Invoke(false);
                    _comunicationUnitMenu.StartComunicationUnitMenu();
                }
            }
        }
    }
}
