using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fart : MonoBehaviour
{
    Player _player = null;
    PlayerMovment _playerMovment = null;
    public FartBar fartBar;
    public float minFart = 0;
    public float maxFart = 10f;
    private float fartDecreaseRate = 2f;
    public bool isFalling = false;
    public float curFart;

    void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _playerMovment = _player.GetComponent<PlayerMovment>();
    }

    void Start()
    {
        curFart = 5f;
        fartBar.SetMaxFart(maxFart);
        fartBar.SetFart(curFart);
    }

    void Update()
    {
        DecreaseFartInAir();
        GravityInAir();
    }

    void DecreaseFartInAir()
    {
        if (!_player.hitGround && curFart > 0)
        {
            curFart -= Time.deltaTime * fartDecreaseRate;
            fartBar.SetFart(curFart);
        }
    }

    void GravityInAir()
    {
        if (!_playerMovment.isRuning && curFart <= 0)
        {
            isFalling = true;
            _playerMovment.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
