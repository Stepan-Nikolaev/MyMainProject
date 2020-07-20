using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _hunger;
    [SerializeField] private float _timeHunger;
    [SerializeField] private float _periodHunger;
    [SerializeField] private float _timeDrink;
    [SerializeField] private float _periodDrink;
    [SerializeField] private float _countWaterDrinking;
    [SerializeField] private Greenhouse _greenhouse;
    [SerializeField] private SewageTreatment _sewageTreatment;

    private Animator _animator;

    public event UnityAction<float> HungerChanged;
    public event UnityAction<bool> CanMoveChanged;
    public event UnityAction<bool> PlayerHungry;
    public event UnityAction PlayerDie;

    private void Start()
    {
        _hunger = 0;
        Time.timeScale = 1;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_timeHunger <= 0)
        {
            _hunger = Mathf.Clamp(_hunger + 10, 0, 100);
            _timeHunger = _periodHunger;
            HungerChanged?.Invoke(_hunger);
        }
        else
        {
            _timeHunger -= Time.deltaTime;
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
            TakeCanMove(false);
            PlayerDie?.Invoke();
        }

        if (!_sewageTreatment.CheckCountWater())
        {
            TakeCanMove(false);
            PlayerDie?.Invoke();
        }

        if (_hunger >= 80)
        {
            PlayerHungry?.Invoke(true);
        }
        else
        {
            PlayerHungry?.Invoke(false);
        }
    }

    public void Eaten()
    {
        _animator.SetBool("BackIdle", false);


        if (_greenhouse.TakeFood())
        _hunger = Mathf.Clamp(_hunger - 50, 0, 100);

        HungerChanged?.Invoke(_hunger);
    }

    public void TakeCanMove(bool canMove)
    {
        CanMoveChanged?.Invoke(canMove);
        _animator.Play("Back_Idle");
    }
}
