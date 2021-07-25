using UnityEngine;

public class Bean : MonoBehaviour
{
    private Fart _fart;
    public int beanVal = 5;
    private FartBar _fartBar = null;
    float floatSpeed = 3.0f;
    // private bool bounce = true;

    private void Awake()
    {
        _fart = GameObject.FindWithTag("Player").GetComponent<Fart>();
        _fartBar = GameObject.FindWithTag("FartBar").GetComponent<FartBar>();
    }

    private void Update()
    {
        floatSpeed = Random.Range(1f, 3f);
    }

    public void EatBean(Collider collider)
    {
        if (_fart.curFart < _fart.maxFart)
        {
            _fart.curFart += beanVal;
            _fartBar.SetFart(_fart.curFart);
        }
        Destroy(collider.gameObject);
    }
}
