using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _normalModeButtonText;
    [SerializeField] private TextMeshProUGUI _hardcoreModeButtonText;

    private GameSettings _gameSettings;

    private void Start()
    {
        _gameSettings = FindObjectOfType<GameSettings>();

        if (_gameSettings.HardcoreMode)
        {
            SetHardcorelMode();
        }
        else
        {
            SetNormalMode();
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneNames.MainMenu);
    }

    public void SetNormalMode()
    {
        _normalModeButtonText.color = Color.green;
        _hardcoreModeButtonText.color = Color.black;
        _gameSettings.HardcoreMode = false;
    }

    public void SetHardcorelMode()
    {
        _normalModeButtonText.color = Color.black;
        _hardcoreModeButtonText.color = Color.green;
        _gameSettings.HardcoreMode = true;
    }
}
