using UnityEngine;
using UnityEngine.AI;

public class EnemySpriteController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _enemyNavMeshAgent;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _spriteRenderer.flipX = _enemyNavMeshAgent.velocity.x < 0;
    }
}