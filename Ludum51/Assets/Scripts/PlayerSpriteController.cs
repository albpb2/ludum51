using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _characterSpriteRenderer;
    [SerializeField] private SpriteRenderer _gunSpriteRenderer;

    private Plane plane = new Plane(Vector3.up, 0);

    private void Update()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            var mousePositionInWorld = ray.GetPoint(distance);
            mousePositionInWorld = new Vector3(mousePositionInWorld.x, transform.position.y, mousePositionInWorld.z);

            _characterSpriteRenderer.flipX = mousePositionInWorld.x < transform.position.x;
            _gunSpriteRenderer.flipX = mousePositionInWorld.x < transform.position.x;
        }
    }
}