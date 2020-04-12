using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Speed;

    [SerializeField] private int _food = 10;
    [SerializeField] private float _hunger = 0;
    [SerializeField] private float _metals = 10;

    [SerializeField] private float _time;
    [SerializeField] private float _period;
    [SerializeField] private float _timeDrink;
    [SerializeField] private float _periodDrink;
    [SerializeField] private float _countWaterDrinking;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _move;
    private string _mainMenu = "MainMenu";
    private bool _isVictory = false;

    [SerializeField] private ComunicationUnitMenu _comunicationUnitMenu;
    [SerializeField] private MiningRobot _miningRobot;
    [SerializeField] private Greenhouse _greenhouse;
    [SerializeField] private MiningRobotMenu _miningRobotMenu;
    [SerializeField] private SewageTreatment _sewageTreatment;
    [SerializeField] private PowerManagement _powerMenagement;
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private TMP_Text _foodCount;
    [SerializeField] private TMP_Text _hungerCount;
    [SerializeField] private TMP_Text _metalsCount;
    [SerializeField] private CanvasGroup _alertPanel;
    [SerializeField] private ReactorMenu _reactorMenu;
    [SerializeField] private GreenhouseMenu _greenhouseMenu;
    [SerializeField] private CanvasGroup _gameOver;
    [SerializeField] private CanvasGroup _victory;
    [SerializeField] private CanvasGroup _welcome;

    void Start()
    {
        Time.timeScale = 1;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _move = true;

        _foodCount.text = _food.ToString() + " порций";
        _hungerCount.text = _hunger.ToString() + " %";
        _metalsCount.text = _metals.ToString() + " кг";

        _welcome.alpha = 1;
        _welcome.interactable = true;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (_time <= 0)
        {
            _hunger += 10;
            _time = _period;
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

        _foodCount.text = _food.ToString() + " порций";
        _hungerCount.text = Mathf.Clamp(_hunger, 0, 100).ToString() + " %";
        _metalsCount.text = _metals.ToString() + " кг";

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

        _foodCount.text = _food.ToString() + " порций";
        _hungerCount.text = _hunger.ToString() + " %";
        _metalsCount.text = _metals.ToString() + " кг";

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
        _food -= 1;
        _hunger -= 50;
    }

    public void TakeHarvest(int countHarvest)
    {
        _food += countHarvest;
        TurnMovement(true);
    }

    public void TakeSpoil(int countSpoil)
    {
        _metals += countSpoil;
        TurnMovement(true);
    }

    public void TurnMovement(bool turnOn)
    {
        _animator.SetBool("BackIdle", !turnOn);
        _move = turnOn;
    }

    public bool GiveMetals(int countGivenMetal)
    {
        if (countGivenMetal <= _metals)
        {
            _metals -= countGivenMetal;

            return true;
        }
        else
        {
            return false;
        }
    }

    public void Victory()
    {
        _isVictory = true;
    }
}
