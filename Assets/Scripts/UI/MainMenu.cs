using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool _authorsOpened = false;
    public void Play(string levelLabel)
    {
        SceneManager.LoadScene(levelLabel);
    }

    public void Authors(Animator animator)
    {
        _authorsOpened = !_authorsOpened;

        animator.SetBool("IsOpen", _authorsOpened);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
