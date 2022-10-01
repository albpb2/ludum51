using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private List<ParticleCollisionEvent> _collisionEvents = new List<ParticleCollisionEvent>();

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _particleSystem.Play();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Hit");
        _particleSystem.GetCollisionEvents(other, _collisionEvents);
    }
}
