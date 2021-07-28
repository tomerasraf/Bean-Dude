using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("Player Speed")]
    [SerializeField] private float playerSpeed = 5.5f;
    [SerializeField] private float maxPlayerSpeed = 25f;
    [SerializeField] private float minPlayerSpeed = 15f;
    private Player _player = null;
    [Header("Player Needed Attachments")]
    public Fart _fart = null;
    public ParticleSystem particle = null;
    public Animator _anim = null;
    public Touch touch;
    private Rigidbody playerRb = null;
    private Vector3 touchedPos;

    [Header("Player Controller")]

    [SerializeField] private float PlayerSwipeSpeed = 15f;
    [SerializeField] float SwipeToFallSpeed = 2f;
    [SerializeField] float onFartSpeed = 2.5f;
    [SerializeField] float fartForce = 7f;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;
    public bool isFarting = false;



    private void Awake()
    {
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


    void Update()
    {
        MovePlayer();
        IsPlayerOnGround();
        PlayerController();
        JumpControl();
        // SpeedUpOnFart();
    }

    private void IsPlayerOnGround()
    {
        if (_player.hitGround)
        {
            _anim.SetBool("OnGround", true);
        }
        else
        {
            _anim.SetBool("OnGround", false);
        }
    }

    private void MovePlayer()
    {
        transform.position = transform.position + Vector3.forward * Time.deltaTime * playerSpeed;
    }

    private void PlayerController()
    {
        if (!GetComponent<Fart>().isFalling)
        {
            if (Input.touchCount > 0)
            {
                Touch firstTouch = Input.GetTouch(0);
                if (firstTouch.phase == TouchPhase.Stationary || firstTouch.phase == TouchPhase.Moved)
                {
                    touchedPos = Camera.main.ScreenToWorldPoint(new Vector3
                   (firstTouch.position.x, firstTouch.position.y, Camera.main.WorldToScreenPoint(transform.position).z));


                    // Clamping the touched Position Value
                    Vector3 clampedPosition = touchedPos;
                    clampedPosition.x = Mathf.Clamp(clampedPosition.x, -5f, 5f);
                    touchedPos = clampedPosition;

                    // 
                    touchedPos.y = transform.position.y;
                    touchedPos.z = transform.position.z;

                    transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime * PlayerSwipeSpeed);
                }
            }
        }
    }

    public void SwipeToFly()
    {
        if (Input.touchCount < 0 && Input.touches[0].phase == TouchPhase.Stationary || Input.touches[0].phase == TouchPhase.Moved)
        {
            isFarting = true;
            _anim.SetBool("IsJumping", true);
            playerRb.velocity = Vector3.up * fartForce;

            //clamp the hight velocity value
            Vector3 clampedHightPosition = transform.position;
            clampedHightPosition.y = Mathf.Clamp(clampedHightPosition.y, -11f, 9f);
            transform.position = clampedHightPosition;
        }
        else
        {
            isFarting = false;
            _anim.SetBool("IsJumping", false);
        }
    }

    public void SwipeToFall()
    {
        playerRb.AddForce(Vector3.down * SwipeToFallSpeed, ForceMode.Impulse);
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
            playerSpeed += onFartSpeed * Time.deltaTime;
        }
        else
        {
            playerSpeed -= onFartSpeed * Time.deltaTime;
        }

        if (playerSpeed >= maxPlayerSpeed)
        {
            playerSpeed = maxPlayerSpeed;
        }

        if (playerSpeed <= minPlayerSpeed)
        {
            playerSpeed = minPlayerSpeed;
        }

    }


}
