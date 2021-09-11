using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour
{
    [SerializeField] float fanRotationSpeed = 5f;

    void Update()
    {
        Vector3 rotateTo = new Vector3(0, 0, fanRotationSpeed * Time.deltaTime);
        transform.Rotate(rotateTo, Space.Self);
    }
}
