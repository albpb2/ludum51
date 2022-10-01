using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarCanvas : MonoBehaviour
{
    [SerializeField] NavMeshEnemyController enemyController;

    // Update is called once per frame
    void Update()
    {
        transform.position = enemyController.transform.position + new Vector3 (0, 4f, 1.5f); 
    }
}
