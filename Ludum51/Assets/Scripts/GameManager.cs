using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;

    private ComputerController[] computerControllers;
    private TimerController _timerController;
    private DoorController _doorController;
    private bool _is10SecondsAlarmPlaying;
    private bool _is5SecondsAlarmPlaying;
    private bool _is3SecondsAlarmPlaying;

    public bool IsPaused { get; set; }

    public static void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#elif !UNITY_WEBGL && !UNITY_WEBPLAYER
            Application.Quit(); // original code to quit Unity player
#endif
    }

    // Start is called before the first frame update
    void Start()
    {
        Pause();

        computerControllers = FindObjectsOfType<ComputerController>();
        _timerController = FindObjectOfType<TimerController>();
        _doorController = FindObjectOfType<DoorController>();
        _timerController.OnTimerFinish += GameOver;
    }

    private void OnEnable()
    {
        if (_timerController != null)
        {
            _timerController.OnTimerFinish += GameOver;
        }
    }

    private void OnDisable()
    {
        _timerController.OnTimerFinish -= GameOver;
    }

    public void VictoryCheck()
    {
        var hackComputerCounter = 0;
        if (computerControllers != null)
        {
            for (int i = 0; i < computerControllers.Length; i++)
            {
                if (computerControllers[i].IsHacked)
                {
                    hackComputerCounter++;
                }
            }

            if (hackComputerCounter == computerControllers.Length)
            {
                //Victory
                _doorController.UnlockDoor();
                Debug.Log("All Computers have been Hacked Congrats");
            }
        }
        else
        {
            Debug.Log("None Computer recognized/detected");
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        if (IsPaused)
        {
            Resume();
            pausePanel.SetActive(false);
        }
        else
        {
            Pause();
            pausePanel.SetActive(true);
        }
    }

    public void Pause()
    {
        if (AudioManagerController.instance.tenSecondsAlarm.isPlaying)
        {
            _is10SecondsAlarmPlaying = true;
        }
        else if (AudioManagerController.instance.fiveSecondsAlarm.isPlaying)
        {
            _is5SecondsAlarmPlaying = true;
        }
        else if (AudioManagerController.instance.threeSecondsAlarm.isPlaying)
        {
            _is3SecondsAlarmPlaying = true;
        }

        AudioManagerController.instance.PauseAllAlarm();
        IsPaused = true;
        Time.timeScale = 0;

    }

    public void Resume()
    {
        if (_is10SecondsAlarmPlaying)
        {
            AudioManagerController.instance.PlayTenSecondsAlarm();
            _is10SecondsAlarmPlaying = false;
        }
        else if (_is5SecondsAlarmPlaying)
        {
            AudioManagerController.instance.PlayFiveSecondsAlarm();
            _is5SecondsAlarmPlaying = false;
        }
        else if (_is3SecondsAlarmPlaying)
        {
            AudioManagerController.instance.PlayThreeSecondsAlarm();
            _is3SecondsAlarmPlaying = false;
        }

        IsPaused = false;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        AudioManagerController.instance.StopAllAlarm();
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
