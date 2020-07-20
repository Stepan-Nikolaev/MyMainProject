using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    private CanvasGroup _canvasAllButtonMenu;
    private Modul _modul;
    private PlayerMover _player;
    private Image _buttonOpenIcon;
    private Button _buttonOpen;
    private bool _playerNearModul;

    private void Start()
    {
        _buttonOpenIcon = GetComponent<Image>();
        _buttonOpen = GetComponent<Button>();
        _canvasAllButtonMenu = GetComponent<CanvasGroup>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Modul modul))
        {
            _modul = modul;
        }

        if (collision.TryGetComponent(out PlayerMover player))
        {
            _player = player;
            _playerNearModul = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover player))
        {
            _playerNearModul = false;
        }
    }

    private void Update()
    {
        if (_playerNearModul)
        {
            ShowButton();
        }
        else
            HideButton();
    }

    public void ShowButton()
    {
        if (_modul.GetCanUseRoom() && _player.CanAction)
        {
            _canvasAllButtonMenu.interactable = true;
            _canvasAllButtonMenu.blocksRaycasts = true;
            _buttonOpen.enabled = true;
            _buttonOpenIcon.enabled = true;
        }
    }

    public void HideButton()
    {
        _canvasAllButtonMenu.interactable = false;
        _canvasAllButtonMenu.blocksRaycasts = false;
        _buttonOpen.enabled = false;
        _buttonOpenIcon.enabled = false;
    }
}
