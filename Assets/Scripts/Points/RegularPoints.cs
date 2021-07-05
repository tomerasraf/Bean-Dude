using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RegularPoints : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
