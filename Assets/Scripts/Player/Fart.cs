using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fart : MonoBehaviour
{
    Player _player = null;
    PlayerMovment _playerMovment = null;
    public FartBar fartBar;
    public float maxFart = 10f;
    private float fartBurnRate = 10f;
    public bool isFalling = false;
    public float curFart;
    private Animator _anim;

    void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _playerMovment = _player.GetComponent<PlayerMovment>();
        _anim = _player.GetComponentInParent<Animator>();
    }

    void Start()
    {
        curFart = maxFart;
        fartBar.SetMaxFart(maxFart);
        fartBar.SetFart(curFart);
    }
    [System.Obsolete]
    void Update()
    {
        DecreaseFartInAir();
    }

    [System.Obsolete]
    public void DecreaseFartInAir()
    {
        if (curFart > 0 && _playerMovment.isFarting)
        {
            curFart -= Time.deltaTime * fartBurnRate;
            _playerMovment.particle.enableEmission = true;
            fartBar.SetFart(curFart);
        }
        else
        {
            _playerMovment.particle.enableEmission = false;
        }

        if (curFart <= 0)
        {
            _anim.SetBool("IsJumping", false);
            _playerMovment.isFarting = false;
            _playerMovment.particle.enableEmission = false;
        }

        if (curFart > maxFart)
        {
            curFart = maxFart;
        }

    }

}
