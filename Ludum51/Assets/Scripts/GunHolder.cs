using UnityEngine;

public class GunHolder : MonoBehaviour
{
    [SerializeField] private Transform _pivot;

    private void Update()
    {
        var mousePositionInWorld = MousePositionInWorld.Instance.Value;
        mousePositionInWorld.y = transform.position.y;
        var pivotToMousePosition = mousePositionInWorld - _pivot.position;
        var angle = Vector3.Angle(pivotToMousePosition, transform.right);

        // DO NOT EVER TOUCH THIS
        var cross = Vector3.Cross(pivotToMousePosition, transform.right);
        if (cross.y < 0)
        {
            angle = -angle;
        }

        transform.RotateAround(_pivot.position, Vector3.down, angle);
    }
}