using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    private PlayerMovment _playerMovment = null;
    private Player _player = null;
    private Fart _fart;
    private Vector2 startPos;
    public int pixelDistToDetect = 100;
    private bool fingerDown;

    private void Awake()
    {
        _playerMovment = GameObject.FindWithTag("Player").GetComponent<PlayerMovment>();
        _fart = _playerMovment.GetComponent<Fart>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            fingerDown = true;
        }

        if (fingerDown)
        {
            if (Input.touches[0].position.y >= startPos.y + pixelDistToDetect)
            {
                if (_fart.curFart > 0)
                {
                    _playerMovment.SwipeToFly();
                }

                if (fingerDown && Input.touches[0].phase == TouchPhase.Ended)
                {
                    fingerDown = false;
                }

            }
        }
        if (fingerDown && !_playerMovment.isFarting)
        {
            if (Input.touches[0].position.y <= startPos.y - pixelDistToDetect)
            {
                if (!_player.hitGround)
                {
                    _playerMovment.SwipeToFall();
                }
                fingerDown = false;

            }
        }

    }

}
