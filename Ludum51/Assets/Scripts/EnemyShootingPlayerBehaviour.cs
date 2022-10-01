using System.Collections;
using UnityEngine;

public class EnemyShootingPlayerBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyGun _enemyGun;

    private bool _isPlayerInTrigger;
    private RaycastHit _raycastHit;
    private NavMeshAgentController _playerController;
    private Transform _playerTransform;
    private Transform _parentTransform;

    private void Start()
    {
        Debug.Log("Starting EnemyShootingPlayerBehaviour");
        _playerController = FindObjectOfType<NavMeshAgentController>(); 
        _playerTransform = _playerController.gameObject.transform;
        _parentTransform = transform.parent.transform;
        StartCoroutine(TryShootPlayer());
    }

    private void Update()
    {
        if (_isPlayerInTrigger)
        {
            Vector3 targetDirection = _playerTransform.position - _parentTransform.position;
            const int rotationSpeed = 5;
            float singleStep = rotationSpeed * Time.deltaTime;
            Vector3.RotateTowards(_parentTransform.forward, targetDirection, singleStep, 0.0f);
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            Debug.DrawRay(_parentTransform.position, newDirection, Color.red);
            _parentTransform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Agent))
        {
            _isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Tags.Agent))
        {
            _isPlayerInTrigger = false;
        }
    }

    private IEnumerator TryShootPlayer()
    {
        while (true)
        {
            if (_isPlayerInTrigger)
            {
                var direction = _playerController.transform.position - gameObject.transform.position;
                const float maxDistance = 30;
                Physics.Raycast(transform.position, direction, out _raycastHit, maxDistance);
                if (_raycastHit.transform.CompareTag(Tags.Agent))
                {
                    _enemyGun.Shoot();
                }
            }
            yield return new WaitForSeconds(.2f);
        }
    }
}

