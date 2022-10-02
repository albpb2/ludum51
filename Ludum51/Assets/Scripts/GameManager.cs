using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsKeyPressed { get; set; }
    [SerializeField] Canvas gameOverCanvas;

    private ComputerController[] computerControllers;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        computerControllers = FindObjectsOfType<ComputerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
