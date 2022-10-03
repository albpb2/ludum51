using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIgnoreArea : MonoBehaviour
{
    private NavMeshEnemyController _enemyController;
    // Start is called before the first frame update
    void Start()
    {
        _enemyController = GetComponentInParent<NavMeshEnemyController>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Tags.Agent))
        {
            _enemyController.StopFollowingPlayer();
        }
    }
}
