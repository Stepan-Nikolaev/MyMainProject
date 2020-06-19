using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private MiningRobot _miningRobot;
    [SerializeField] private ComunicationUnitMenu _comunicationUnitMenu;
    [SerializeField] private MiningMenu _miningMenu;
    [SerializeField] private Greenhouse _greenhouse;
    [SerializeField] private GreenhouseMenu _greenhouseMenu;
    [SerializeField] private MiningRobotMenu _miningRobotMenu;
    [SerializeField] private PlantMenu _plantMenu;
    [SerializeField] private PowerMenu _powerMenu;
    [SerializeField] private ComunicationUnit _comunicationUnit;
    [SerializeField] private ReactorMenu _reactorMenu;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private bool _canMove;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _canMove = true;
    }

    private void OnEnable()
    {
        _player.CanMoveChanged += OnCanMoveChanged;
        _playerInput.CanMoveChanged += OnCanMoveChanged;
        _progressBar.CanMoveChanged += OnCanMoveChanged;
        _miningRobot.CanMoveChanged += OnCanMoveChanged;
        _comunicationUnitMenu.CanMoveChanged += OnCanMoveChanged;
        _miningMenu.CanMoveChanged += OnCanMoveChanged;
        _greenhouse.CanMoveChanged += OnCanMoveChanged;
        _greenhouseMenu.CanMoveChanged += OnCanMoveChanged;
        _miningRobotMenu.CanMoveChanged += OnCanMoveChanged;
        _plantMenu.CanMoveChanged += OnCanMoveChanged;
        _powerMenu.CanMoveChanged += OnCanMoveChanged;
        _comunicationUnit.CanMoveChanged += OnCanMoveChanged;
        _reactorMenu.CanMoveChanged += OnCanMoveChanged;
    }

    private void OnDisable()
    {
        _player.CanMoveChanged -= OnCanMoveChanged;
        _playerInput.CanMoveChanged += OnCanMoveChanged;
        _progressBar.CanMoveChanged -= OnCanMoveChanged;
        _miningRobot.CanMoveChanged -= OnCanMoveChanged;
        _comunicationUnitMenu.CanMoveChanged -= OnCanMoveChanged;
        _miningMenu.CanMoveChanged -= OnCanMoveChanged;
        _greenhouse.CanMoveChanged -= OnCanMoveChanged;
        _greenhouseMenu.CanMoveChanged -= OnCanMoveChanged;
        _miningRobotMenu.CanMoveChanged -= OnCanMoveChanged;
        _plantMenu.CanMoveChanged -= OnCanMoveChanged;
        _powerMenu.CanMoveChanged -= OnCanMoveChanged;
        _comunicationUnit.CanMoveChanged -= OnCanMoveChanged;
        _reactorMenu.CanMoveChanged -= OnCanMoveChanged;
    }

    private void OnCanMoveChanged(bool canMove)
    {
        _animator.SetBool("BackIdle", !canMove);
        _canMove = canMove;
    }

    private void FixedUpdate()
    {
        if (_canMove)
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

            _rigidbody.velocity = new Vector2(direction * _speed, _rigidbody.velocity.y);
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
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, direction * _speed);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stairs"))
        {
            _rigidbody.gravityScale = 1;
        }
    }
}
