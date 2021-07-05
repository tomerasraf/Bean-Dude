using UnityEngine;

public class Player : MonoBehaviour
{
    CapsuleCollider _charCollider = null;
    public bool hitGround = false;
    private void Awake()
    {
        _charCollider = GetComponent<CapsuleCollider>();
    }
    private void FixedUpdate()
    {
        GroundCheck();
    }

    void GroundCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float check = (_charCollider.height + _charCollider.radius) / 35f;
            hitGround = hit.distance <= check;
        }
        else
        {
            hitGround = false;
        }
    }

}