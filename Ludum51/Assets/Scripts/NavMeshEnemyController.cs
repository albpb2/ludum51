using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemyController : MonoBehaviour
{
    private const string ColorChange = "EnemyColorChangeByHit";

    [SerializeField] FillEnemyHealthBar fillEnemyHealthBar;

    private Animator _enemyAnimator;
    private DamageHandler _damageHandler;

    public int HP { get; set; } = 100;
    public int HpMax { get; set; } = 100;

    private void Start()
    {
        _enemyAnimator = GetComponentInParent<Animator>();
        _damageHandler = GetComponent<DamageHandler>();

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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("you are dead");
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
            if (HP <= 0)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
