using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    public void Resume()
    {
        _gameManager.ToggleMenu();
    }
    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #elif !UNITY_WEBGL && !UNITY_WEBPLAYER
            Application.Quit(); // original code to quit Unity player
        #endif
    }
}
