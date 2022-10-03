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
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 9)
        {
            _timerText.text = "" + (int)(TimeLeft + 1);
        }
        else
        {
            _timerText.text = "" + (int)(TimeLeft + 1);
        }

        if (TimeLeft <= 0.0f)
        {
            //OnTimerFinish?.Invoke();
        }
    }

    public void ResetTimer()
    {
        TimeLeft = 10f;
        OnTimerRestart?.Invoke();
    }
}
