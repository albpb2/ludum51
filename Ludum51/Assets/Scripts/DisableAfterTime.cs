using System.Collections;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    [SerializeField] private float _seconds;

    private void OnEnable()
    {
        StartCoroutine(WaitAndDisable());
    }

    private IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(_seconds);
        gameObject.SetActive(false);
    }
}