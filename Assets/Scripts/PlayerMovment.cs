﻿using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private SceneLoader sceneLoader = null;
    private Rigidbody playerRb = null;
    private Player _player = null;
    public Touch touch;

    [Header("Speed")]
    public float speed = 20f;
    public bool isRuning = true;

    [Header("Jump")]
    public bool allowJump = true;
    public float jumpForce = 20f;
    public float jumpCooldown = 1f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;



    private void Awake()
    {
        sceneLoader = GameObject.FindWithTag("SceneLoader").GetComponent<SceneLoader>();
        playerRb = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();

    }
    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        if (isRuning)
        {
            DoubleTapJump();
            JumpControl();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FlyCollider"))
        {
            isRuning = false;
            playerRb.useGravity = false;
        }

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

                    if (isRuning)
                    {
                        touchedPos.y = transform.position.y;
                        touchedPos.x = transform.position.x;
                    }

                    transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime * speed);
                }
            }
        }
    }

    public void DoubleTapJump()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.tapCount == 2 && _player.hitGround)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    playerRb.velocity = Vector3.up * jumpForce;
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
