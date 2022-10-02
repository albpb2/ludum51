using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentController : MonoBehaviour
{
    public float HP { get; set; } = 100f;
    public float HpMax { get; set; } = 100f;

    [SerializeField] FillHealthBar fillHealthBar;
    [SerializeField] float m_Speed = 5f;
    [SerializeField] float maxComputerSearchDistance = 1.5f;
    [SerializeField] float radius = 1.5f;

    private Animator playerAnimator;
    private string colorChange = "PlayerColorChangeByHit";
    private GameManager gameManager;
    private Rigidbody rigidbody;
    private Plane plane = new Plane(Vector3.up, 0);
    private RaycastHit [] computerRayCastResults = new RaycastHit [20];

    // Start is called before the first frame update
    void Start()
    {
        fillHealthBar.FillSliderValue();
        gameManager = FindObjectOfType<GameManager>();
        rigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rigidbody.MovePosition(transform.position + playerInput * Time.deltaTime * m_Speed);

        //float distance;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (plane.Raycast(ray, out distance))
        //{
        //    var mousePositionInWorld = ray.GetPoint(distance);
        //    mousePositionInWorld = new Vector3(mousePositionInWorld.x, transform.position.y, mousePositionInWorld.z);
        //    var targetDir = mousePositionInWorld - transform.position;
        //    var forward = transform.forward;
        //    var localTarget = transform.InverseTransformPoint(mousePositionInWorld);

        //    var angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        //    var eulerAngleVelocity = new Vector3(0, angle, 0);
        //    var deltaRotation = Quaternion.Euler(eulerAngleVelocity);
        //    rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
        //}
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

    public void ReceiveDamage(int damage)
    {
        if (damage > 0)
        {
            HP -= damage;
            fillHealthBar.gameObject.SetActive(true);
            fillHealthBar.FillSliderValue();
            playerAnimator.Play(colorChange, 0, 0.0f);
            if (HP <= 0)
            {
                gameManager.GameOver();
            }
            Debug.Log("ouch, it hurts" + HP);
        }
    }
}
