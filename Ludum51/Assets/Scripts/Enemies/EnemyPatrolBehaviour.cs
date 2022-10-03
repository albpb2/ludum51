using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolBehaviour : MonoBehaviour
{
    [SerializeField] GameObject _routeBegin;
    [SerializeField] GameObject _routeEnd;

    private NavMeshAgent _enemyAgent;
    private NavMeshEnemyController _enemyController;
    private bool _isAtBegin;

    // Start is called before the first frame update
    void Start()
    {
        _enemyAgent = GetComponent<NavMeshAgent>();
        _enemyController = GetComponent<NavMeshEnemyController>();
        if(_routeBegin != null && _routeEnd != null && !_enemyController.IsPlayerInArea)
        {
            _enemyAgent.destination = _routeBegin.transform.position;
            _isAtBegin = true;
        }
    }

    public void InvokeToggleDestination()
    {
        if (_routeBegin != null && _routeEnd != null && !_enemyController.IsPlayerInArea)
        {
            StartCoroutine(ToggleDestination());
        }
    }

    IEnumerator ToggleDestination()
    {
        Debug.Log("Entra");
        if (_isAtBegin && !_enemyController.IsPlayerInArea)
        {
            Debug.Log("Deberia ir al end");
            yield return new WaitForSeconds(1f);
            _enemyAgent.destination = _routeEnd.transform.position;
        }
        else if (!_isAtBegin && !_enemyController.IsPlayerInArea)
        {
            yield return new WaitForSeconds(1f);
            _enemyAgent.destination = _routeBegin.transform.position;
        }
        _isAtBegin = !_isAtBegin;
    }
}
