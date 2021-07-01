using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpecielPoint : MonoBehaviour
{
    private int specPoints = 5;
    public RegularPoints _points = null;
    public TextMeshProUGUI points;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _points.curPoints += specPoints;
            points.text = _points.curPoints.ToString();
            Destroy(gameObject);
        }
    }
}
