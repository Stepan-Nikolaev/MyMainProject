using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ReactorMenu : Menu
{
    [SerializeField] private Button _levelUpButton;
    [SerializeField] private Reactor _reactor;
    [SerializeField] private int _currentCountMetalsForLevelUp;
    [SerializeField] private string _currentState;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private Text _textButtonLevelUp;

    private void Start()
    {
        _windowMenu = GetComponent<CanvasGroup>();
        MenuUpdate();
    }

    private void OnEnable()
    {
        _reactor.StateChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        _reactor.StateChanged -= OnStateChanged;
    }

    private void OnStateChanged (ReactorStates newReactorState)
    {
        _currentCountMetalsForLevelUp = newReactorState.MetalsForNextLevel;
        _currentState = newReactorState.State;

        if (newReactorState.StateNumber == 3)
        {
            _levelUpButton.interactable = false;
        }

        MenuUpdate();
    }

    public void MenuUpdate()
    {
        _textButtonLevelUp.text = $"Ремонт/n {_currentCountMetalsForLevelUp} кг металла";
        _label.text = $"Состояние: {_currentState}";
    }
}
