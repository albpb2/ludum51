using UnityEngine;

public class EnemyGun : Gun
{
    public void Shoot()
    {
        Debug.Log("Shooting");
        ParticleSystem.Play();
    }
}
