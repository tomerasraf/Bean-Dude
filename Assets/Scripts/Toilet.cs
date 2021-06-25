using UnityEngine;

public class Toilet : MonoBehaviour
{
    private Fart _fart;
    private FartBar _fartBar = null;
    private void Start()
    {
        _fart = GameObject.FindWithTag("Player").GetComponent<Fart>();
        _fartBar = GameObject.FindWithTag("FartBar").GetComponent<FartBar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_fart.curFart > 0)
            {
                _fart.curFart -= 10;
                _fartBar.SetFart(_fart.curFart);
            }
            Destroy(gameObject);
        }
    }
}
