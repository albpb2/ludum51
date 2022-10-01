using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemyController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("you are dead");
    }
}
