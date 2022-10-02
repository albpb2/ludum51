using UnityEngine;

public class MousePositionInWorld : MonoBehaviour
{
    public static MousePositionInWorld Instance { get; private set; }

    private Plane plane = new Plane(Vector3.up, 0);

    public Vector3 Value { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            Value = ray.GetPoint(distance);
            Value = new Vector3(Value.x, transform.position.y, Value.z);
        }
    }
}