using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float offsetY = 7f;
    private float offsetZ = -16f;

    [SerializeField] private Transform player = null;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(
            0,
            offsetY,
            player.position.z + offsetZ);
    }
}
