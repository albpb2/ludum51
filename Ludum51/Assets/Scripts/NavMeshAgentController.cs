using System.Collections;
using UnityEngine;

public class NavMeshAgentController : MonoBehaviour
{
    public float HP { get; set; } = 100f;
    public float HpMax { get; set; } = 100f;

    [SerializeField] FillHealthBar fillHealthBar;
    [SerializeField] float m_Speed = 5f;
    [SerializeField] float maxComputerSearchDistance = 1.5f;
    [SerializeField] float radius = 1.5f;

    private DoorController _doorController;
    private GameManager _gameManager;
    private Rigidbody _rigidbody;
    private DamageHandler _damageHandler;
    private CinemachineCameraShake _cinemachineCameraShake;
    private PlayerSpriteController _playerSpriteController;
    private Animator _playerAnimator;
    private RaycastHit [] computerRayCastResults = new RaycastHit [20];
    private bool _isImmune;


    public float Speed => m_Speed;

    private void Awake()
    {
        _isImmune = false;

        _rigidbody = GetComponent<Rigidbody>();
        _damageHandler = GetComponent<DamageHandler>();
        _playerSpriteController = GetComponentInChildren<PlayerSpriteController>();
        _playerAnimator = _playerSpriteController.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        fillHealthBar.FillSliderValue();
        _gameManager = FindObjectOfType<GameManager>();
        _cinemachineCameraShake = FindObjectOfType<CinemachineCameraShake>();
        _doorController = FindObjectOfType<DoorController>();

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
                }else if (computerRayCastResults[i].transform.CompareTag("Door"))
                {
                    _doorController.PressKey();
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
            if(!_isImmune)
            {
                HP -= damage;
                fillHealthBar.gameObject.SetActive(true);
                fillHealthBar.FillSliderValue();
                StartCoroutine(ActivateInmunity());
            }
           
            if (HP <= 0)
            {
                AudioManagerController.instance.PlaySFX(12);
                //StartCoroutine("Ending");
                _gameManager.GameOver();
            }
            else
            {
                _cinemachineCameraShake.Shake(5f, .1f);
            }
            Debug.Log("ouch, it hurts" + HP);
        }
    }

    public IEnumerator Ending()
    {
        _playerAnimator.SetTrigger("Death");
        yield return new WaitForSeconds(2f);
        _gameManager.GameOver();

    }

    public IEnumerator ActivateInmunity()
    {
        _isImmune = true;
        _playerAnimator.SetTrigger("Hit");
        yield return new WaitForSeconds(0.2f);
        _isImmune = false;
    }


}
