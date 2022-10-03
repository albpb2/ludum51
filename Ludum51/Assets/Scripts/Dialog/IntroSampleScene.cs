using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSampleScene : MonoBehaviour
{
    [SerializeField] IntroDialogScript _dialogScript;
    [SerializeField] GameObject _dialogPanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!_dialogPanel.activeInHierarchy)
        {
            return;
        }

        if (!_dialogScript.IsStarted)
        {
            Time.timeScale = 0f;
            _dialogScript.TryPlayNextLine();
        }

        if (Input.GetMouseButtonDown(0) && !_dialogScript.IsFinished)
        {
            _dialogScript.TryPlayNextLine();
        }

        if (_dialogScript.IsFinished)
        {
            Time.timeScale = 1f;
            _dialogPanel.SetActive(false);

            Debug.Log("Es aqui?");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
