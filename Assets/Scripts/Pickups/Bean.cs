using UnityEngine;

public class Bean : MonoBehaviour
{
    private Fart _fart;
    public int beanVal = 5;
    private FartBar _fartBar = null;
    [SerializeField] float amplitude = 2f;
    [SerializeField] float frequency = 2f;
    // private bool bounce = true;

    private void Awake()
    {
        _fart = GameObject.FindWithTag("Player").GetComponent<Fart>();
        _fartBar = GameObject.FindWithTag("FartBar").GetComponent<FartBar>();
    }

    private void Update()
    {
        float y = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(transform.position.x, 1.5f + y, transform.position.z);
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
