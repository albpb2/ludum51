using UnityEngine;

public class EnemyFollowingObjet : MonoBehaviour
{
    [SerializeField] NavMeshEnemyController enemyController;
    [SerializeField] Vector3 _offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = enemyController.transform.position + _offset;
    }
}
