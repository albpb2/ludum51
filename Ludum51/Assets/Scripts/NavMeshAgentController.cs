using UnityEngine;

public class NavMeshAgentController : MonoBehaviour
{
    public float HP { get; set; } = 100f;
    public float HpMax { get; set; } = 100f;

    [SerializeField] FillHealthBar fillHealthBar;
    [SerializeField] float m_Speed = 5f;
    [SerializeField] float maxComputerSearchDistance = 1.5f;
    [SerializeField] float radius = 1.5f;

    private Animator _playerAnimator;
    private string colorChange = "PlayerColorChangeByHit";
    private GameManager _gameManager;
    private Rigidbody _rigidbody;
    private DamageHandler _damageHandler;
    private CinemachineCameraShake _cinemachineCameraShake;
    private RaycastHit [] computerRayCastResults = new RaycastHit [20];

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();
        _damageHandler = GetComponent<DamageHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        fillHealthBar.FillSliderValue();
        _gameManager = FindObjectOfType<GameManager>();
        _cinemachineCameraShake = FindObjectOfType<CinemachineCameraShake>();

        _damageHandler.OnDamageTaken += ReceiveDamage;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _rigidbody.MovePosition(transform.position + playerInput * Time.deltaTime * m_Speed);
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

    private void OnEnable()
    {
        if (_damageHandler != null)
        {
            _damageHandler.OnDamageTaken += ReceiveDamage;
        }
    }

    private void OnDisable()
    {
        _damageHandler.OnDamageTaken -= ReceiveDamage;
    }

    public void ReceiveDamage(int damage)
    {
        if (damage > 0)
        {
            HP -= damage;
            fillHealthBar.gameObject.SetActive(true);
            fillHealthBar.FillSliderValue();
            _playerAnimator.Play(colorChange, 0, 0.0f);
            if (HP <= 0)
            {
                _gameManager.GameOver();
            }
            else
            {
                _cinemachineCameraShake.Shake(5f, .1f);
            }
            Debug.Log("ouch, it hurts" + HP);
        }
    }
}
