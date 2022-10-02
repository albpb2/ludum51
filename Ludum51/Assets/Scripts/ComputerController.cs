using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    private GameManager gameManager;

    public TextMeshProUGUI alarmText;
    public bool isHacked;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine("ManageAlarm");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ManageAlarm()
    {
        while (true)
        {
            gameManager.IsKeyPressed = false;
            yield return new WaitForSeconds(10);
            alarmText.transform.gameObject.SetActive(true);

            if (!gameManager.IsKeyPressed)
            {
                Debug.Log("No has pulsado la alarma a tiempo");
                gameManager.GameOver();
            }
        }
    }
    public void PressKey()
    {
        alarmText.transform.gameObject.SetActive(false);
        gameManager.IsKeyPressed = true;
        isHacked = true;
        gameManager.VictoryCheck();
        Debug.Log("Tecla E Pulsada");
    }
}
