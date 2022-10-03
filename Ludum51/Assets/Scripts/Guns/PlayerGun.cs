using UnityEngine;

public class PlayerGun : Gun
{
    private GameManager _gameManager;
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponentInParent<Animator>();
    }

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_gameManager.IsPaused)
        {
            ParticleSystem.Play();
            AudioManagerController.instance.PlaySFXPitch(1);
            _animator.SetTrigger("Shoot");
        }
    }
}
