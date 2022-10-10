using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public delegate void TimerRestartEvent();
    public event TimerRestartEvent OnTimerRestart;
    public delegate void TimerFinishEvent();
    public event TimerFinishEvent OnTimerFinish;
    [SerializeField] TextMeshProUGUI _timerText;
    public float TimeLeft { get; private set; } = 10f;

    private NavMeshAgentController _playerController;
    private bool _is10SecondsTimerPLayed;
    private bool _is5SecondsTimerPLayed;
    private bool _is3SecondsTimerPlayed;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = FindObjectOfType<NavMeshAgentController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.IsDead)
        {
            return;
        }

        TimeLeft -= Time.deltaTime;
        _timerText.text = "" + Mathf.Min((int)(TimeLeft + 1), 10);
        ChangeTimerSound();

        if (TimeLeft <= 0.0f)
        {
            OnTimerFinish?.Invoke();
        }
    }

    private void ChangeTimerSound()
    {
        if ((int)TimeLeft == 10 && !_is10SecondsTimerPLayed)
        {
            _is10SecondsTimerPLayed = true;
            AudioManagerController.instance.PlayTenSecondsAlarm();
            //play first timer sound
        }
        else if ((int)TimeLeft == 4 && !_is5SecondsTimerPLayed)
        {
            _is5SecondsTimerPLayed = true;
            AudioManagerController.instance.PlayFiveSecondsAlarm();
            //play second timer sound
        }
        else if ((int)TimeLeft == 2 && !_is3SecondsTimerPlayed)
        {
            _is3SecondsTimerPlayed = true;
            AudioManagerController.instance.PlayThreeSecondsAlarm();
            //play third timer sound
        }
    }

    public void ResetTimer()
    {
        _is10SecondsTimerPLayed = false;
        _is5SecondsTimerPLayed  = false;
        _is3SecondsTimerPlayed  = false;
        AudioManagerController.instance.StopAllAlarm();

        TimeLeft = 10f;
        OnTimerRestart?.Invoke();
    }

}
