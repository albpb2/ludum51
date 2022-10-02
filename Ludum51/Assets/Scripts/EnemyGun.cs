using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag(Tags.Agent))
        {
            Debug.Log("Player hit");
            var playerHealth = other.GetComponent<NavMeshAgentController>();
            const int gunDamage = 20;
            playerHealth.ReceiveDamage(gunDamage);
        }
    }

    public void Shoot()
    {
        _particleSystem.Play();
    }
}
