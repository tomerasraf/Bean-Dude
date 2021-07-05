using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private SceneLoader sceneLoader = null;
    public Fart _fart = null;
    private Rigidbody playerRb = null;
    private Player _player = null;
    public Touch touch;

    public ParticleSystem particle = null;

    [Header("Speed & Ground")]
    [SerializeField] float speed = 20f;

    [Header("Fly")]
    public float fartForce = 7f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public bool isFarting = false;
    public Animator _anim = null;



    private void Awake()
    {
        sceneLoader = GameObject.FindWithTag("SceneLoader").GetComponent<SceneLoader>();
        playerRb = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
        _fart = GetComponent<Fart>();
        particle = this.GetComponentInChildren<ParticleSystem>();
        _anim = GetComponentInParent<Animator>();
    }

    [System.Obsolete]
    private void Start()
    {
        particle.enableEmission = false;
    }

    [System.Obsolete]
    void Update()
    {
        if (_player.hitGround)
        {
            _anim.SetBool("OnGround", true);
        }
        else
        {
            _anim.SetBool("OnGround", false);
        }


        Move();
        DoubleTapFly();
        JumpControl();
    }



    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("FlyingWall"))
        {
            sceneLoader.RestartLevel();
        }

        if (other.gameObject.CompareTag("EndLine"))
        {
            sceneLoader.RestartLevel();
        }
    }

    private void Move()
    {
        if (!GetComponent<Fart>().isFalling)
        {
            if (Input.touchCount > 0)
            {
                Touch firstTouch = Input.GetTouch(0);
                if (firstTouch.phase == TouchPhase.Stationary || firstTouch.phase == TouchPhase.Moved)
                {
                    Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3
                    (firstTouch.position.x, firstTouch.position.y, Camera.main.WorldToScreenPoint(transform.position).z));

                    touchedPos.y = transform.position.y;
                    touchedPos.x = transform.position.x;

                    transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime * speed);
                }
            }
        }
    }

    [System.Obsolete]
    public void DoubleTapFly()
    {
        if (Input.touchCount > 0 && _player.hitGround)
        {
            touch = Input.GetTouch(0);
            if (touch.tapCount == 2 && _fart.curFart > 0)
            {
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    isFarting = true;
                    _anim.SetBool("IsJumping", true);
                    playerRb.velocity = Vector3.up * fartForce;
                }
                else
                {
                    isFarting = false;
                    _anim.SetBool("IsJumping", false);
                }
            }

        }
        else if (Input.touchCount > 0 && !_player.hitGround)
        {
            touch = Input.GetTouch(0);
            if (_fart.curFart > 0)
            {
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    isFarting = true;
                    _anim.SetBool("IsJumping", true);
                    playerRb.velocity = Vector3.up * fartForce;
                }
                else
                {
                    isFarting = false;
                    _anim.SetBool("IsJumping", false);
                }
            }
        }

    }

    void JumpControl()
    {
        if (playerRb.velocity.y < 0)
        {
            playerRb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if (playerRb.velocity.y > 0 && touch.phase != TouchPhase.Stationary)
        {
            playerRb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }
}
