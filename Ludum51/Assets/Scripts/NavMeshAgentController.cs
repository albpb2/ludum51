using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentController : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] float m_Speed = 5f;
    private RaycastHit [] computerRayCastResults = new RaycastHit [20];
    [SerializeField] float maxComputerSearchDistance = 1.5f;
    [SerializeField] float radius = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
       rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rigidbody.MovePosition(transform.position + playerInput * Time.deltaTime * m_Speed);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var resultCount = Physics.SphereCastNonAlloc(transform.position, radius, transform.forward ,computerRayCastResults, maxComputerSearchDistance);
            for (int i = 0; i < resultCount; i++)
            {
                if(computerRayCastResults[i].transform.CompareTag("Computer"))
                {
                    var computerController = computerRayCastResults[i].transform.GetComponent<ComputerController>();
                    computerController.PressKey();
                }
            }
        }
    }
}
