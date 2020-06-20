using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _hunger = 0;
    [SerializeField] private float _timeHunger;
    [SerializeField] private float _periodHunger;
    [SerializeField] private float _timeDrink;
    [SerializeField] private float _periodDrink;
    [SerializeField] private float _countWaterDrinking;
    [SerializeField] private Greenhouse _greenhouse;
    [SerializeField] private SewageTreatment _sewageTreatment;
    [SerializeField] private GameUI _gameUI;
    private Animator _animator;

    public event UnityAction<float> HungerChanged;
    public event UnityAction<bool> CanMoveChanged;

    void Start()
    {
        Time.timeScale = 1;
        _animator = GetComponent<Animator>();
    }

    void Update()
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
            CanMoveChanged?.Invoke(false);
            _gameUI.GameOver();
        }

        if (!_sewageTreatment.CheckCountWater())
        {
            CanMoveChanged?.Invoke(false);
            _gameUI.GameOver();
        }

        if (_hunger >= 80)
        {
            _gameUI.ActivateAlertPanel();
        }
        else
        {
            _gameUI.DeactivateAlertPanel();
        }
    }

    public void Eaten()
    {
        _animator.SetBool("BackIdle", false);


        if (_greenhouse.TakeFood())
        _hunger = Mathf.Clamp(_hunger - 50, 0, 100);

        HungerChanged?.Invoke(_hunger);
    }
}
