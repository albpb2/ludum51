using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemyController : MonoBehaviour
{
    public int HP { get; set; } = 100;
    public int HpMax { get; set; } = 100;

    [SerializeField] FillEnemyHealthBar fillEnemyHealthBar;
    private void Start()
    {
        fillEnemyHealthBar.slider.gameObject.SetActive(false);
        ReceiveDamage(10);
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
            Debug.Log("ouch, it hurts" + HP);
        }
    }
}
