using UnityEngine;

public class PlayerGun : Gun
{
    private GameManager _gameManager;

    protected override void Awake()
    {
        base.Awake();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_gameManager.IsPaused)
        {
            ParticleSystem.Play();
        }
    }
}
