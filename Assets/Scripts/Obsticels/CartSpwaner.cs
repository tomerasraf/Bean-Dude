using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartSpwaner : MonoBehaviour
{
    // cart will spwan in front of the player and move forward, the cart should spwan randomly bettwen 4 and -4 X axis position.

    [SerializeField] float cartSpeed = 2;
    Transform playerPosition;

    private void Update()
    {
        playerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>();

        MoveCart();

        if (transform.position.z < playerPosition.position.z - 100f)
        {
            DestroyCopy(transform.gameObject);
        }

    }

    void MoveCart()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z * cartSpeed * Time.deltaTime);
    }

    void DestroyCopy(GameObject cartCopy)
    {
        Destroy(cartCopy);
    }
}
