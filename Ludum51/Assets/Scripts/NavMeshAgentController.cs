using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentController : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] float m_Speed = 5f; 
    
    Plane plane = new Plane(Vector3.up, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        rigidbody.MovePosition(transform.position + playerInput * Time.deltaTime * m_Speed);



        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            var mousePositionInWorld = ray.GetPoint(distance);
            mousePositionInWorld = new Vector3(mousePositionInWorld.x, transform.position.y, mousePositionInWorld.z);
            var targetDir = mousePositionInWorld - transform.position;
            var forward = transform.forward;
            var localTarget = transform.InverseTransformPoint(mousePositionInWorld);

            var angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

            var eulerAngleVelocity = new Vector3(0, angle, 0);
            var deltaRotation = Quaternion.Euler(eulerAngleVelocity);
            rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
        }



    }
}
