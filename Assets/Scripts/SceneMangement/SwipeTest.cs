using UnityEngine;

public class SwipeTest : MonoBehaviour
{
    public PlayerMovment _playerMovment;
    public SwipeDetection swipeControls;
    public Animator _anim = null;
    public Fart _fart = null;

    Transform playerTransform = null;
    private void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _anim = GameObject.FindWithTag("Player").GetComponentInParent<Animator>();
        _fart = GameObject.FindWithTag("Player").GetComponent<Fart>();
    }

    private void Update()
    {
        if (swipeControls.SwipeUp && _fart.curFart > 0)
        {
            _playerMovment.SwipeToFly();
            _playerMovment.isFarting = true;
            _anim.SetBool("IsJumping", true);
        }
        else
        {
            _playerMovment.isFarting = false;
            _anim.SetBool("IsJumping", false);
        }

        if (swipeControls.SwipeDown)
        {
            _playerMovment.SwipeToFall();
        }

        // if (swipeControls.SwipeLeft)
        // {
        //     if (playerTransform.position.x != -2f)
        //     {
        //         Vector3 direction = Vector3.left * 2;
        //         playerTransform.transform.Translate(direction, Space.Self);
        //     }
        // }

        // if (swipeControls.SwipeRight)
        // {
        //     if (playerTransform.position.x != 2f)
        //     {
        //         Vector3 direction = Vector3.right * 2;
        //         playerTransform.transform.Translate(direction, Space.Self);
        //     }
        // }
    }
}