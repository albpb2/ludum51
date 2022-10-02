using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _characterSpriteRenderer;
    [SerializeField] private SpriteRenderer _gunSpriteRenderer;

    private void Update()
    {
        var flip = MousePositionInWorld.Instance.Value.x < transform.position.x;

        _characterSpriteRenderer.flipX = flip;
        _gunSpriteRenderer.flipX = flip;
    }
}