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

    private GameManager _gameManager;
    private bool _is10SecondsTimerPLayed;
    private bool _is5SecondsTimerPLayed;
    private bool _is3SecondsTimerPlayed;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
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
        else if ((int)TimeLeft == 5 && !_is5SecondsTimerPLayed)
        {
            _is5SecondsTimerPLayed = true;
            AudioManagerController.instance.PlayFiveSecondsAlarm();
            //play second timer sound
        }
        else if ((int)TimeLeft == 3 && !_is3SecondsTimerPlayed)
        {
            _is3SecondsTimerPlayed = true;
            AudioManagerController.instance.PlayThreeSecondsAlarm();
            //play third timer sound
        }
    }

    public void ResetTimer()
    {
        TimeLeft = 10f;
        OnTimerRestart?.Invoke();

        _is10SecondsTimerPLayed = false;
        _is5SecondsTimerPLayed  = false;
        _is3SecondsTimerPlayed  = false;
    }

}
