using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas pauseMenuCanvas;

    private ComputerController[] computerControllers;
    public bool IsPaused { get; set; }

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
                if (computerControllers[i].isHacked)
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
            pauseMenuCanvas.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pauseMenuCanvas.gameObject.SetActive(true);
        }
        
    }

    public void GameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
