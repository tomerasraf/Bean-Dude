using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazorPathing : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints = null;
    [SerializeField] private float razorSpeed = 10f;
    [SerializeField] Transform razor = null;
    private Transform razorClone;
    int waypointIndex = 0;

    private void Awake()
    {
        PlatformGenerator platformGenerator = GameObject.Find("Platform Generator").GetComponent<PlatformGenerator>();
        razorClone = Instantiate(razor, waypoints[waypointIndex].transform.position, Quaternion.identity);
        razorClone.parent = platformGenerator.platformCopy.transform;
    }

    private void Update()
    {
        if (razorClone != null)
        {
            Move();
        }
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;

            var movmentThisFrame = razorSpeed * Time.deltaTime;
            razorClone.position = Vector3.MoveTowards(razorClone.position, targetPosition, movmentThisFrame);

            if (razorClone.position == targetPosition)
            {
                waypointIndex++;
                razorSpeed = Random.Range(5f, 10f);
            }

            if (razorClone.position == waypoints[1].transform.position)
            {
                waypointIndex = 0;
                razorSpeed = Random.Range(5f, 10f);
            }

        }
    }
}
