using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    CapsuleCollider _charCollider = null;
    public bool hitGround = false;
    public float distanceTravelled = 0f;
    public float mileStone = 500f;
    public float curMileStone;
    Vector3 lastPosition;
    public int distanceTravelledInt;
    [SerializeField] TextMeshProUGUI metersTravelledText = null;
    PlayerMovment _playerMovment;


    private void Awake()
    {
        _charCollider = GetComponent<CapsuleCollider>();
        _playerMovment = GetComponent<PlayerMovment>();
    }
    private void Start()
    {
        lastPosition = transform.position;
        mileStone = 500f;
        curMileStone = mileStone;
    }
    private void FixedUpdate()
    {
        GroundCheck();
    }

    private void Update()
    {
        CalculateDistance();
        PlayerSpeedByMilestone();
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
        distanceTravelledInt = (int)Mathf.Round(distanceTravelled);
        metersTravelledText.text = distanceTravelledInt.ToString() + "M";
    }

    void PlayerSpeedByMilestone()
    {
        if (distanceTravelled > mileStone)
        {
            _playerMovment.playerSpeed += _playerMovment.playerIncreaseSpeedRate;
            curMileStone = mileStone += distanceTravelled;
            mileStone = curMileStone;
        }
    }
}