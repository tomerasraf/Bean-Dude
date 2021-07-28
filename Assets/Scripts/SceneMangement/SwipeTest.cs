using UnityEngine;

public class SwipeTest : MonoBehaviour
{
    public PlayerMovment _playerMovment;
    public SwipeDetection swipeControls;

    private void Update()
    {
        if (swipeControls.SwipeUp)
        {
            _playerMovment.SwipeToFly();
        }

        if (swipeControls.SwipeDown)
        {
            _playerMovment.SwipeToFall();
        }
    }
}