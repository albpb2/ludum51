using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;

    private ComputerController[] computerControllers;
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
        Time.timeScale = 1f;
        computerControllers = FindObjectsOfType<ComputerController>();
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
        IsPaused = !IsPaused;
        if (!IsPaused)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
