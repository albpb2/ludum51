using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool _isUnlock;
    [SerializeField] Animator _doorAnimator;
    [SerializeField] TypingGameController _typingPanel;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void UnlockDoor()
    {
        _isUnlock = true;
        Debug.Log("Door Unlock");
    }

    public void PressKey()
    {
        if (_isUnlock)
        {
            _doorAnimator.SetTrigger("IsOpen");
            AudioManagerController.instance.PlaySFX(4);
            StartCoroutine(ShowTypingPanelWithDelay());
        }
        else
        {
            _doorAnimator.SetTrigger("Error");
            AudioManagerController.instance.PlaySFX(11);
        }
    }

    IEnumerator ShowTypingPanelWithDelay()
    {
        yield return new WaitForSeconds(1);
        _gameManager.Pause();
        _typingPanel.gameObject.SetActive(true);
    }
}
