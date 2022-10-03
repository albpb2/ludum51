using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    private const string ColorChangeAnimationTriggerName = "PlayerColorChangeByHit";
    private const string MoveAnimationBoolName = "Moving";

    [SerializeField] private SpriteRenderer _characterSpriteRenderer;
    [SerializeField] private SpriteRenderer _gunSpriteRenderer;

    private Animator _playerAnimator;
    private Rigidbody _rigidbody;
    private NavMeshAgentController _controller;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _rigidbody = GetComponentInParent<Rigidbody>();
        _controller = GetComponentInParent<NavMeshAgentController>();
    }

    private void Update()
    {
        var flip = MousePositionInWorld.Instance.Value.x < transform.position.x;

        _characterSpriteRenderer.flipX = flip;
        _gunSpriteRenderer.flipY = flip;

        Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _playerAnimator.SetBool(MoveAnimationBoolName, Mathf.Abs(playerInput.x) > .1 || Mathf.Abs(playerInput.z) > .1);
    }

    public void PlayHitColorChange()
    {
        _playerAnimator.Play(ColorChangeAnimationTriggerName, 0, 0.0f);
    }
}