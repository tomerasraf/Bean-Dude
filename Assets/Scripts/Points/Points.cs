using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI pointsText = null;
    public int curPoints = 0;
    public int userPoints;
    private void Start()
    {
        curPoints = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("regPoint"))
        {
            curPoints += 3;
            pointsText.text = curPoints.ToString();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("specPoint"))
        {
            curPoints += 5;
            pointsText.text = curPoints.ToString();
            Destroy(other.gameObject);
        }
    }

    public void DisplayRegularPoints(Collider collider)
    {
        curPoints += 3;
        pointsText.text = curPoints.ToString();
        Destroy(collider.gameObject);
    }
    public void DisplaySpacielPoints(Collider collider)
    {
        curPoints += 5;
        pointsText.text = curPoints.ToString();
        Destroy(collider.gameObject);
    }
}

