using UnityEngine;
using UnityEngine.AI;

public class EnemySpriteController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _enemyNavMeshAgent;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private NavMeshEnemyController _navMeshEnemyController;
    private Transform _playerTransform;

    private RaycastHit _raycastHit;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _navMeshEnemyController = _enemyNavMeshAgent.GetComponent<NavMeshEnemyController>();
        _playerTransform = FindObjectOfType<NavMeshAgentController>().transform;
    }

    private void Update()
    {
        if (_navMeshEnemyController.IsDead)
        {
            return;
        }

        if (_navMeshEnemyController.IsPlayerInArea)
        {
            if (Physics.Raycast(transform.position, _playerTransform.position - transform.position, out _raycastHit, 30)
                && _raycastHit.transform.CompareTag(Tags.Agent))
            {
                _spriteRenderer.flipX = _playerTransform.position.x < transform.position.x;
            }
        }
        else
        {
            _spriteRenderer.flipX = _enemyNavMeshAgent.velocity.x < 0;
        }

        _animator.SetBool("IsRunning", _enemyNavMeshAgent.velocity.magnitude > .0001f);
    }
}