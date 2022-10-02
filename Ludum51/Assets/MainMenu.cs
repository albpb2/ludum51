using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneNames.Game);
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
