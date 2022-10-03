using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteChange : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetInstanceID() == _enemy.GetInstanceID())
        {
            _enemy.GetComponent<EnemyPatrolBehaviour>().InvokeToggleDestination();
        }
    }
}
