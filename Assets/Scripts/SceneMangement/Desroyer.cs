using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desroyer : MonoBehaviour
{
    Transform playerPosition = null;

    private float offsetZ = -100f;

    private void Awake()
    {
        playerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        Vector3 offSetPosition = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 2.8f, 10f), offsetZ + playerPosition.position.z);
        transform.position = offSetPosition;



    }


    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }


}
