using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemyController : MonoBehaviour
{
    private const string ColorChange = "EnemyColorChangeByHit";
    private Vector3 _initialPosition;

    [SerializeField] FillEnemyHealthBar fillEnemyHealthBar;

    private Animator _enemyAnimator;
    private DamageHandler _damageHandler;
    private EnemyDetectionArea _enemyDetectionArea;
    private NavMeshAgent _agent;
    private EnemyPatrolBehaviour _enemyPatrolBehaviour;
    private CinemachineCameraShake _cinemachineCameraShake;

    public bool IsPlayerInArea { get; private set; }
    public int HP { get; set; } = 100;
    public int HpMax { get; set; } = 100;

    private void Start()
    {
        _initialPosition = transform.position;
        _enemyAnimator = GetComponentInParent<Animator>();
        _damageHandler = GetComponent<DamageHandler>();
        _agent = GetComponent<NavMeshAgent>();
        _enemyDetectionArea = GetComponent<EnemyDetectionArea>();
        _enemyPatrolBehaviour = GetComponent<EnemyPatrolBehaviour>();
        _cinemachineCameraShake = FindObjectOfType<CinemachineCameraShake>();

        _damageHandler.OnDamageTaken += ReceiveDamage;

        fillEnemyHealthBar.slider.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (_damageHandler != null)
        {
            _damageHandler.OnDamageTaken += ReceiveDamage;
        }
    }

    private void OnDisable()
    {
        _damageHandler.OnDamageTaken -= ReceiveDamage;
    }

    public void StopFollowingPlayer()
    {
        IsPlayerInArea = false;
        _enemyPatrolBehaviour.InvokeToggleDestination();
    }

    public void FollowPlayer(GameObject player)
    {
        IsPlayerInArea = true;
        StartCoroutine(UpdatePlayerPosition(player));
    }

    IEnumerator UpdatePlayerPosition(GameObject player)
    {
        while (IsPlayerInArea)
        {
            _agent.destination = player.transform.position;
            yield return new WaitForSeconds(.5f);
        }
        _agent.destination = _initialPosition;
    }

    public void ReceiveDamage(int damage)
    {
        if (damage > 0)
        {
            HP -= damage;
            fillEnemyHealthBar.slider.gameObject.SetActive(true);
            fillEnemyHealthBar.FillEnemySliderValue();
            _enemyAnimator.Play(ColorChange, 0, 0.0f);
            Debug.Log("ouch, it hurts" + HP);
            _cinemachineCameraShake.Shake(5f, .1f);
            if (HP <= 0)
            {
                AudioManagerController.instance.PlaySFX(14);
                Destroy(transform.parent.gameObject);
            }

        }
    }
}
