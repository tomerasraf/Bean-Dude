using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    //     private PlayerMovment _playerMovment = null;
    //     private Player _player = null;
    //     private Fart _fart;
    //     private Vector2 startPos;
    //     public int pixelDistToDetect = 100;
    //     private bool fingerDown;
    //     private bool swipingUp = false;FF

    //     private void Awake()
    //     {
    //         _playerMovment = GameObject.FindWithTag("Player").GetComponent<PlayerMovment>();
    //         _fart = _playerMovment.GetComponent<Fart>();
    //         _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    //     }

    //     private void Update()
    //     {
    //         DetectSwipe();
    //     }

    //     private void DetectSwipe()
    //     {
    //         if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
    //         {
    //             startPos = Input.touches[0].position;
    //             fingerDown = true;
    //         }

    //         if (fingerDown)
    //         {
    //             if (Input.touches[0].position.y >= startPos.y + pixelDistToDetect)
    //             {
    //                 if (_fart.curFart > 0)
    //                 {
    //                     _playerMovment.SwipeToFly();
    //                     swipingUp = true;
    //                 }
    //             }
    //         }
    //         if (fingerDown && !swipingUp)
    //         {
    //             if (Input.touches[0].position.y <= startPos.y - pixelDistToDetect)
    //             {
    //                 if (!_player.hitGround)
    //                 {
    //                     _playerMovment.SwipeToFall();
    //                 }
    //                 fingerDown = false;

    //             }
    //         }

    //         if (fingerDown && Input.touches[0].phase == TouchPhase.Ended)
    //         {
    //             fingerDown = false;
    //             swipingUp = false;
    //         }

    //     }

    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }


        // Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;

        }

        // Did we cross the deadzone?

        if (swipeDelta.magnitude > 125)
        {
            // Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or rigth
                if (x < 0)
                {
                    swipeLeft = true;
                    Reset();
                }

                else
                    swipeRight = true;
                    Reset();
            }
            else
            {
                //Up or down
                if (y < 0)
                {
                    swipeDown = true;
                    Reset();
                }

                else
                    swipeUp = true;
            }


        }

    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }

}
