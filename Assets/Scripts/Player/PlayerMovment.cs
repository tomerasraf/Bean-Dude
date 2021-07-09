using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("World Speed")]
    public MoveToMe _worldSpeed = null;
    public float maxWorldSpeed = 25f;
    public float minWorldSpeed = 15f;
    private SceneLoader sceneLoader = null;
    private Player _player = null;
    [Header("Player Needed Attachments")]
    public Fart _fart = null;
    public ParticleSystem particle = null;
    public Animator _anim = null;
    public Touch touch;
    private float PlayerSwipeSpeed = 15f;
    private Rigidbody playerRb = null;

    [Header("Fly")]
    public float onFartSpeed = 2.5f;
    public float fartForce = 7f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public bool isFarting = false;



    private void Awake()
    {
        sceneLoader = GameObject.FindWithTag("SceneLoader").GetComponent<SceneLoader>();
        playerRb = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
        _fart = GetComponent<Fart>();
        particle = this.GetComponentInChildren<ParticleSystem>();
        _anim = GetComponentInParent<Animator>();
        _worldSpeed = GameObject.FindWithTag("WorldSpeed").GetComponent<MoveToMe>();
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
        SpeedUpOnFart();
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

                    transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime * PlayerSwipeSpeed);
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


    void SpeedUpOnFart()
    {
        if (isFarting)
        {
            _worldSpeed.speed += onFartSpeed * Time.deltaTime;
        }
        else
        {
            _worldSpeed.speed -= onFartSpeed * Time.deltaTime;
        }

        if (_worldSpeed.speed >= maxWorldSpeed)
        {
            _worldSpeed.speed = maxWorldSpeed;
        }

        if (_worldSpeed.speed <= minWorldSpeed)
        {
            _worldSpeed.speed = minWorldSpeed;
        }

    }


}
