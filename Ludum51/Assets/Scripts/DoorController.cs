using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    private bool _isUnlock;
    [SerializeField] Animator _doorAnimator;
   
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
            StartCoroutine(ChangeSceneWithDelay());
        }
        else
        {
            _doorAnimator.SetTrigger("Error");
            AudioManagerController.instance.PlaySFX(11);
            //play red door animation
        }
    }
    IEnumerator ChangeSceneWithDelay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
