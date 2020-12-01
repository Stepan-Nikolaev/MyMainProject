using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerAction _playerAction;
    [SerializeField] private ProgressBar _progressBar;
    private Animator _animator;

    public event UnityAction CloseWelcomeWindow;
    public event UnityAction EscPressed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _animator.Play("Back_Idle");
            _playerAction.StartAction("Eaten");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CloseWelcomeWindow?.Invoke();
        }
    }
}
