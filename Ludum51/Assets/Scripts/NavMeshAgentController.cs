using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentController : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] float m_Speed = 5f;
    private RaycastHit [] computerRayCastResults = new RaycastHit [20];
    [SerializeField] float maxComputerSearchDistance = 5f;
    [SerializeField] float radius = 5f;

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
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            for(int i = 0; i < computerRayCastResults.Length; i++)
            {
                if(computerRayCastResults[i].transform.CompareTag("Computer"))
                {
                    var computerController = computerRayCastResults[i].transform.GetComponent<ComputerController>();
                    
                }
            }
        }
    }
}
