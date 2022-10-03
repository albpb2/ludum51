using TMPro;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    public TextMeshProUGUI alarmText;

    private GameManager _gameManager;
    private GameSettings _gameSettings;
    private ComputerSystem _computerSystem;
    private TimerController _timerController;

    public bool IsHacked { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _computerSystem = FindObjectOfType<ComputerSystem>();
        _timerController = FindObjectOfType<TimerController>();
        _gameSettings = FindObjectOfType<GameSettings>();
        _computerSystem.OnKeyPressed += DisableAlarmText;
        _computerSystem.OnCountdownRestarted += EnableAlarmText;
        
    }

    private void OnEnable()
    {
        if (_computerSystem != null)
        {
            _computerSystem.OnKeyPressed += DisableAlarmText;
            _computerSystem.OnCountdownRestarted += EnableAlarmText;
        }
    }

    private void OnDisable()
    {
        _computerSystem.OnKeyPressed -= DisableAlarmText;
        _computerSystem.OnCountdownRestarted -= EnableAlarmText;
    }

    public void PressKey()
    {
        if (_timerController.TimeLeft > 3)
        {
            return;
        }
        if (IsHacked && _gameSettings.HardcoreMode)
        {
            return;
        }

        _computerSystem.PressKey();
        IsHacked = true;
        AudioManagerController.instance.PlaySFX(3);
        gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        _gameManager.VictoryCheck();
    }

    private void EnableAlarmText()
    {
        alarmText.transform.gameObject.SetActive(true);
    }

    private void DisableAlarmText()
    {
        alarmText.transform.gameObject.SetActive(false);
    }
}
