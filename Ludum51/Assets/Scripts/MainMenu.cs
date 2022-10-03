using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        if (!AudioManagerController.instance.menuTheme.isPlaying)
        {
            AudioManagerController.instance.PlayMenuTheme();
        } 
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneNames.Intro);
    }

    public void GoToOptionsMenu()
    {
        SceneManager.LoadScene(SceneNames.OptionsMenu);
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene(SceneNames.Credits);
    }

    public void Exit()
    {
        GameManager.Exit();
    }
}
