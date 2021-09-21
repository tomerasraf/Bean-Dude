using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    PauseMenu _pauseMenu = null;
    private SceneLoader _sceneLoader = null;
    private Bean _bean = null;
    PlatformGenerator _platfromGenerator;
    [SerializeField] ParticleSystem beanParticle = null;

    private void Awake()
    {
        _sceneLoader = GameObject.FindWithTag("SceneLoader").GetComponent<SceneLoader>();
        _pauseMenu = GameObject.Find("Canvas").GetComponent<PauseMenu>();
        _platfromGenerator = GameObject.FindWithTag("Platform Generator").GetComponent<PlatformGenerator>();
    }

    private void Update()
    {
        _bean = GameObject.FindWithTag("Bean").GetComponent<Bean>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bean"))
        {
            _bean.EatBean(other);
            ParticleSystem particleClone = Instantiate(beanParticle, other.transform.position, other.transform.rotation);
            particleClone.transform.parent = _platfromGenerator.platformCopy.transform;
        }

        if (other.CompareTag("Obsticle"))
        {
            _pauseMenu.PauseGame();
        }
    }
}
