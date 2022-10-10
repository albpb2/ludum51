using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionArea : MonoBehaviour
{
    private NavMeshAgentController _player;
    private NavMeshEnemyController _enemyController;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<NavMeshAgentController>();
        _enemyController = GetComponentInParent<NavMeshEnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Agent) && !_player.IsDead)
        {
            _enemyController.FollowPlayer(_player);
        }
    }
}
