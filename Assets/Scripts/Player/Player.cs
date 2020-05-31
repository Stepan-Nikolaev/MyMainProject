using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float Speed;

    [SerializeField] private float _hunger = 0;
    [SerializeField] private float _time;
    [SerializeField] private float _period;
    [SerializeField] private float _timeDrink;
    [SerializeField] private float _periodDrink;
    [SerializeField] private float _countWaterDrinking;
    [SerializeField] private ComunicationUnitMenu _comunicationUnitMenu;
    [SerializeField] private MiningRobot _miningRobot;
    [SerializeField] private Greenhouse _greenhouse;
    [SerializeField] private MiningRobotMenu _miningRobotMenu;
    [SerializeField] private SewageTreatment _sewageTreatment;
    [SerializeField] private PowerManagement _powerMenagement;
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private CanvasGroup _alertPanel;
    [SerializeField] private ReactorMenu _reactorMenu;
    [SerializeField] private GreenhouseMenu _greenhouseMenu;
    [SerializeField] private CanvasGroup _gameOver;
    [SerializeField] private CanvasGroup _victory;
    [SerializeField] private CanvasGroup _welcome;
    [SerializeField] private MenuExit _menuExit;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _move;
    private string _mainMenu = "MainMenu";
    private bool _isVictory = false;

    public event UnityAction<float> HungerChanged;

    void Start()
    {
        Time.timeScale = 1;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _move = true;

        _welcome.alpha = 1;
        _welcome.interactable = true;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (_time <= 0)
        {
            _hunger = Mathf.Clamp(_hunger + 10, 0, 100);
            _time = _period;
            HungerChanged?.Invoke(_hunger);
        }
        else
        {
            _time -= Time.deltaTime;
        }

        if (_timeDrink <= 0)
        {
            _sewageTreatment.Drink(_countWaterDrinking);
            _timeDrink = _periodDrink;
        }
        else
        {
            _timeDrink -= Time.deltaTime;
        }

        if (_hunger >= 100)
        {
            _animator.SetBool("IsDead", true);
            _gameOver.alpha = 1;
            _gameOver.interactable = true;
            TurnMovement(false);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(_mainMenu);
            }
        }

        if (!_sewageTreatment.CheckCountWater())
        {
            _animator.SetBool("IsDead", true);
            _gameOver.alpha = 1;
            _gameOver.interactable = true;
            TurnMovement(false);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(_mainMenu);
            }
        }

        if (_isVictory)
        {
            _victory.alpha = 1;
            _victory.interactable = true;
            TurnMovement(false);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(_mainMenu);
            }
        }

        if (_welcome.interactable)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _welcome.alpha = 0;
                _welcome.interactable = false;
                Time.timeScale = 1;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_move)
        {
            float direction = Input.GetAxis("Horizontal");

            if (direction < 0)
            {
                _animator.SetBool("LeftWolk", true);
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (direction > 0)
            {
                _animator.SetBool("RightWolk", true);
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                _animator.SetBool("LeftWolk", false);
                _animator.SetBool("RightWolk", false);
            }

            _rigidbody.velocity = new Vector2(direction * Speed, _rigidbody.velocity.y);
        }

        if (_hunger >= 80)
        {
            _alertPanel.alpha = 1;
        }
        else
        {
            _alertPanel.alpha = 0;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stairs"))
        {
            float direction = Input.GetAxis("Vertical");

            if (direction != 0)
            {
                _animator.SetBool("IsStairs", true);
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                _animator.SetBool("IsStairs", false);
                _rigidbody.gravityScale = 0;
            }

            _rigidbody.gravityScale = 0;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, direction * Speed);
        }

        if (collision.gameObject.CompareTag("Greenhouse"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_powerMenagement.UseRoom(1) && !_greenhouse.IsGrowing())
                {
                    _animator.SetBool("LeftWolk", false);
                    _animator.SetBool("RightWolk", false);
                    TurnMovement(false);
                    _greenhouseMenu.StartGreenhouseMenu();
                }
            }
        }

        if (collision.gameObject.CompareTag("PowerStation"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_powerMenagement.UseRoom(2))
                {
                    _animator.SetBool("LeftWolk", false);
                    _animator.SetBool("RightWolk", false);
                    TurnMovement(false);
                    _reactorMenu.StartReactorMenu();
                }
            }
        }

        if (collision.gameObject.CompareTag("MiningRobot"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_powerMenagement.UseRoom(3) && !_miningRobot.IsMining())
                {
                    _animator.SetBool("LeftWolk", false);
                    _animator.SetBool("RightWolk", false);
                    TurnMovement(false);
                    _miningRobotMenu.StartMiningRobotMenu();
                }
            }
        }

        if (collision.gameObject.CompareTag("CommunicationUnit"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_powerMenagement.UseRoom(7))
                {
                    _animator.SetBool("LeftWolk", false);
                    _animator.SetBool("RightWolk", false);
                    TurnMovement(false);
                    _comunicationUnitMenu.StartComunicationUnitMenu();
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stairs"))
        {
            _rigidbody.gravityScale = 1;
        }
    }

    public void Eaten()
    {
        _animator.SetBool("BackIdle", false);


        if (_greenhouse.TakeFood())
        _hunger = Mathf.Clamp(_hunger - 50, 0, 100);

        HungerChanged?.Invoke(_hunger);
    }

    public void TurnMovement(bool turnOn)
    {
        _animator.SetBool("BackIdle", !turnOn);
        _move = turnOn;
    }

    public void Victory()
    {
        _isVictory = true;
    }
}
