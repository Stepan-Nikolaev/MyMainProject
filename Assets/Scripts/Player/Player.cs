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
    [SerializeField] private int _minHungerLavel;
    [SerializeField] private int _maxHungerLavel;
    [SerializeField] private int _alertHungerLavel;
    [SerializeField] private int _countHungerInOnePortionFood;
    [SerializeField] private int _stepGrowthHunger;
    private Animator _animator;
    private Coroutine _proccesLife;
    private bool _isLife;

    public event UnityAction<float> HungerChanged;
    public event UnityAction<bool> CanMoveChanged;
    public event UnityAction<bool> PlayerHungry;
    public event UnityAction PlayerDie;

    private void Start()
    {
        _isLife = true;
        _hunger = 0;
        Time.timeScale = 1;
        _animator = GetComponent<Animator>();
        _proccesLife = StartCoroutine(ProccesLife());
    }

    private void Update()
    {
        if (_hunger >= _maxHungerLavel)
        {
            TakeInfoAboutPlayer(false);
            PlayerDie?.Invoke();
            _isLife = false;
        }

        if (!_sewageTreatment.CheckCountWater)
        {
            TakeInfoAboutPlayer(false);
            PlayerDie?.Invoke();
            _isLife = false;
        }

        if (_hunger >= _alertHungerLavel)
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
        _hunger = Mathf.Clamp(_hunger - _countHungerInOnePortionFood, _minHungerLavel, _maxHungerLavel);

        HungerChanged?.Invoke(_hunger);
    }

    public void TakeInfoAboutPlayer(bool abilityMove)
    {
        CanMoveChanged?.Invoke(abilityMove);
        _animator.Play("Back_Idle");
    }

    private IEnumerator ProccesLife()
    {
        while(_isLife)
        {
            if(_timeHunger <= 0)
            {
                _hunger = Mathf.Clamp(_hunger + _stepGrowthHunger, _minHungerLavel, _maxHungerLavel);
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

            yield return null;
        }
    }
}
