using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    CapsuleCollider _charCollider = null;
    public bool hitGround = false;
    float distanceTravelled = 0f;
    Vector3 lastPosition;
    [SerializeField] TextMeshProUGUI metersTravelledText = null;


    private void Awake()
    {
        _charCollider = GetComponent<CapsuleCollider>();
    }
    private void Start()
    {
        lastPosition = transform.position;
    }
    private void FixedUpdate()
    {
        GroundCheck();
    }

    private void Update()
    {
        CalculateDistance();
    }

    void GroundCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float check = (_charCollider.height + _charCollider.radius) / 20f;
            hitGround = hit.distance <= check;
        }
        else
        {
            hitGround = false;
        }
    }

    void CalculateDistance()
    {
        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
        int distanceTravelledInt = (int)Mathf.Round(distanceTravelled);
        metersTravelledText.text = distanceTravelledInt.ToString() + "M";
    }

}