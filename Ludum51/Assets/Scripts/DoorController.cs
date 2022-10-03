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
            StartCoroutine(ChangeSceneWithDelay());
        }
        else
        {
            //play red door animation
        }
    }
    IEnumerator ChangeSceneWithDelay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
