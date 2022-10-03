using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public delegate void DamageTakenDelegate(int damage);
    public event DamageTakenDelegate OnDamageTaken;

    public void TakeDamage(int damage)
    {
        OnDamageTaken?.Invoke(damage);
    }
}
