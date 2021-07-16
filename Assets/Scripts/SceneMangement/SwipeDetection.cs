using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private PlayerMovment _player;
    [SerializeField] private Fart _fart;
    private Vector2 startPos;
    public int pixelDistToDetect = 20;
    private bool fingerDown;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerMovment>();
        _fart = _player.GetComponent<Fart>();
    }

    private void Update()
    {
        DetectSwipeUp();
    }

    private void DetectSwipeUp()
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
                    _player.SwipeToFly();
                }

            }
        }

        if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            fingerDown = false;
        }
    }
}
