using UnityEngine;

public class EnemyGun : Gun
{
    private GameManager _gameManager;
    [SerializeField] Animator _animator;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void Shoot()
    {
        Debug.Log("Shooting");
        ParticleSystem.Play();
        _animator.SetTrigger("Shoot");
        AudioManagerController.instance.PlaySFXPitch(6);
    }
}
