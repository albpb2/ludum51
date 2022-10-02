﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ComputerSystem : MonoBehaviour
{
    private GameManager _gameManager;

    public delegate void KeyPessedEvent();
    public delegate void CountdownRestartedEvent();
    public event KeyPessedEvent OnKeyPressed;
    public event KeyPessedEvent OnCountdownRestarted;

    public bool IsKeyPressed { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();

        StartCoroutine("ManageAlarm");
    }

    IEnumerator ManageAlarm()
    {
        while (true)
        {
            IsKeyPressed = false;
            yield return new WaitForSeconds(10);

            if (!IsKeyPressed)
            {
                Debug.Log("No has pulsado la alarma a tiempo"); 
                _gameManager.GameOver();
                yield break;
            }

            OnCountdownRestarted?.Invoke();
        }
    }
    public void PressKey()
    {
        IsKeyPressed = true;
        OnKeyPressed?.Invoke();
        Debug.Log("Tecla E Pulsada");
    }
}