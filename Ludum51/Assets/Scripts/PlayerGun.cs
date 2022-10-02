using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private GameManager _gameManager;

    private List<ParticleCollisionEvent> _collisionEvents = new List<ParticleCollisionEvent>();

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_gameManager.IsPaused)
        {
            _particleSystem.Play();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag(Tags.Enemy))
        {
            Debug.Log("Player hit");
            var playerHealth = other.GetComponent<NavMeshEnemyController>();
            const int gunDamage = 10;
            playerHealth.ReceiveDamage(gunDamage);
        }
    }
}
