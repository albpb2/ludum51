using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bulletImpactSparksPrefab;
    [SerializeField] private string _targetTag;
    [SerializeField] private int _gunDamage;

    private ParticleSystem _particleSystem;
    private List<ParticleCollisionEvent> _collisionEvents = new List<ParticleCollisionEvent>();
    private List<ParticleSystem> _shotImpactParticlesPool;
    private int _currentShotImpactParticleIndex;

    protected ParticleSystem ParticleSystem => _particleSystem;

    protected virtual void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _shotImpactParticlesPool = new List<ParticleSystem>(10);
        for (var i = 0; i < 10; i++)
        {
            var particle = Instantiate(_bulletImpactSparksPrefab);
            particle.gameObject.SetActive(false);
            _shotImpactParticlesPool.Add(particle);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag(_targetTag))
        {
            TryDamageTarget(other);
        }
        else
        {
            PlaySparksHitParticle(other);
        }
    }

    private void TryDamageTarget(GameObject target)
    {
        if (target.TryGetComponent<DamageHandler>(out var damageHandler))
        {
            damageHandler.TakeDamage(_gunDamage);
        }
    }

    private void PlaySparksHitParticle(GameObject hitObject)
    {
        var events = _particleSystem.GetCollisionEvents(hitObject, _collisionEvents);
        for (var i = 0; i < events; i++)
        {
            _shotImpactParticlesPool[_currentShotImpactParticleIndex].gameObject.transform.position = _collisionEvents[i].intersection;
            _shotImpactParticlesPool[_currentShotImpactParticleIndex].gameObject.SetActive(true);
            _currentShotImpactParticleIndex++;
            _currentShotImpactParticleIndex = _currentShotImpactParticleIndex % _shotImpactParticlesPool.Count;
        }
    }
}