using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCollider : MonoBehaviour
{
    Transform playerTranform = null;
    float OffsetY = -10f;

    private void Awake()
    {
        playerTranform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = new Vector3(playerTranform.position.x, OffsetY, playerTranform.position.z);
    }
}
