using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemyController : MonoBehaviour
{
    public int HP { get; set; } = 100;
    public int HpMax { get; set; } = 100;

    [SerializeField] FillEnemyHealthBar fillEnemyHealthBar;
    private Animator enemyAnimator;
    private string colorChange = "EnemyColorChangeByHit";
    private void Start()
    {

        enemyAnimator = GetComponentInParent<Animator>();
        fillEnemyHealthBar.slider.gameObject.SetActive(false);
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
            enemyAnimator.Play(colorChange, 0, 0.0f);
            Debug.Log("ouch, it hurts" + HP);
            if (HP <= 0)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
