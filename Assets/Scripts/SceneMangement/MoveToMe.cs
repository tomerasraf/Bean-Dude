using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMe : MonoBehaviour
{
    public float speed = 5.5f;

    void Update()
    {
        transform.position = transform.position + Vector3.forward * Time.deltaTime * speed;
    }
}
