using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RegularPoints : MonoBehaviour
{
    [Header("Points")]
    private int regularPoint = 3;
    public int curPoints = 0;
    public int userPoints = 0;
    GameObject pauseMenuUI;
    public TextMeshProUGUI points;

    private void Start()
    {
        curPoints = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            curPoints += regularPoint;
            points.text = curPoints.ToString();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }



}
