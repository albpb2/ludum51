using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DetectionZoneScript : MonoBehaviour
{
    public NavMeshAgent[] enemy;

    private void Start()
    {
        enemy = FindObjectsOfType<NavMeshAgent>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agent"))
        {
            for(int i = 0; i < enemy.Length; i++)
            {
                if (!enemy[i].CompareTag("Agent"))
                {
                    enemy[i].destination = transform.position;
                }
            }
        }
    }
}
