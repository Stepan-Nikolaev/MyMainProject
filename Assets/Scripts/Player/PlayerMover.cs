using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private bool _canMove;
    private bool _onStairs;

    public bool CanAction => _canMove;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _canMove = true;
    }

    private void OnEnable()
    {
        _player.CanMoveChanged += OnCanMoveChanged;
    }

    private void OnDisable()
    {
        _player.CanMoveChanged -= OnCanMoveChanged;
    }

    private void OnCanMoveChanged(bool canMove)
    {
        if (!canMove)
            _animator.Play("Back_Idle");
        else
            _animator.Play("Front_Idle");

        _canMove = canMove;
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            float direction = Input.GetAxis("Horizontal");

            if (direction < 0)
            {
                if (!_onStairs)
                    _animator.Play("Left_Run");

                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (direction > 0)
            {
                if (!_onStairs)
                    _animator.Play("Right_Run");

                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                if (!_onStairs)
                    _animator.Play("Front_Idle");
            }

            _rigidbody.velocity = new Vector2(direction * _speed, _rigidbody.velocity.y);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Stairs stairs))
        {
            _onStairs = true;
            float direction = Input.GetAxis("Vertical");

            if (direction != 0)
            {
                _animator.Play("Back_Run");
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                _animator.Play("Back_Idle");
                _rigidbody.gravityScale = 0;
            }

            _rigidbody.gravityScale = 0;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, direction * _speed);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Stairs stairs))
        {
            _onStairs = false;
            _rigidbody.gravityScale = 1;
        }
    }
}
