using UnityEngine;

public class GunHolder : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(MousePositionInWorld.Instance.Value);
    }
}