using TMPro;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    private GameManager _gameManager;

    public TextMeshProUGUI alarmText;
    public bool isHacked;

    private ComputerSystem _computerSystem;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _computerSystem = FindObjectOfType<ComputerSystem>();
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
        _computerSystem.PressKey();
        isHacked = true;
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
