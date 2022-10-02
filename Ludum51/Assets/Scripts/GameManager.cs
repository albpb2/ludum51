using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private ComputerController[] computerControllers;

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

    public void GameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
