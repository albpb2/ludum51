using System.Collections;
using UnityEngine;

public class NavMeshAgentController : MonoBehaviour
{
    [SerializeField] FillHealthBar fillHealthBar;
    [SerializeField] float m_Speed = 5f;
    [SerializeField] float maxComputerSearchDistance = 1.5f;
    [SerializeField] float radius = 1.5f;
    [SerializeField] private GunHolder _gunHolder;

    private DoorController _doorController;
    private GameManager _gameManager;
    private Rigidbody _rigidbody;
    private DamageHandler _damageHandler;
    private CinemachineCameraShake _cinemachineCameraShake;
    private PlayerSpriteController _playerSpriteController;
    private Animator _playerAnimator;
    private CapsuleCollider _collider;
    private RaycastHit [] computerRayCastResults = new RaycastHit [20];
    private bool _isImmune;


    public float HP { get; private set; } = 100f;
    public float HpMax { get; private set; } = 100f;
    public float Speed => m_Speed;
    public bool IsDead => HP <= 0;

    private void Awake()
    {
        _isImmune = false;

        _rigidbody = GetComponent<Rigidbody>();
        _damageHandler = GetComponent<DamageHandler>();
        _playerSpriteController = GetComponentInChildren<PlayerSpriteController>();
        _playerAnimator = _playerSpriteController.GetComponent<Animator>();
        _collider = GetComponent<CapsuleCollider>();
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
        if (IsDead)
        {
            return;
        }

        Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _rigidbody.MovePosition(transform.position + playerInput * Time.deltaTime * m_Speed);
    }

    private void Update()
    {
        if (!IsDead && Input.GetKeyDown(KeyCode.E))
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
        if (HP <= 0)
        {
            return;
        }

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
                KillPlayer();
                StartCoroutine(WaitAndEndGame());
            }
            else
            {
                _cinemachineCameraShake.Shake(5f, .1f);
            }
            Debug.Log("ouch, it hurts" + HP);
        }
    }

    public IEnumerator WaitAndEndGame()
    {
        yield return new WaitForSeconds(3f);
        _gameManager.GameOver();

    }

    public IEnumerator ActivateInmunity()
    {
        _isImmune = true;
        _playerAnimator.SetTrigger("Hit");
        yield return new WaitForSeconds(0.2f);
        _isImmune = false;
    }

    private void KillPlayer()
    {
        _playerAnimator.SetBool("IsDead", true);
        AudioManagerController.instance.PlaySFX(12);
        _gunHolder.gameObject.SetActive(false);
        _collider.enabled = false;
    }
}
