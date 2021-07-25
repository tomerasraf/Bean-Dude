using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    private SceneLoader _sceneLoader = null;
    private Points _points = null;
    private Bean _bean = null;

    private void Awake()
    {
        _sceneLoader = GameObject.FindWithTag("SceneLoader").GetComponent<SceneLoader>();
        _points = GetComponent<Points>();

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
        }

        if (other.CompareTag("FlyingWall"))
        {
            _sceneLoader.RestartLevel();
        }

        if (other.CompareTag("regPoint"))
        {
            _points.DisplayRegularPoints(other);
        }

        if (other.CompareTag("specPoint"))
        {
            _points.DisplaySpacielPoints(other);
        }

        if (other.CompareTag("Razor"))
        {
            _sceneLoader.RestartLevel();
        }

        if (other.CompareTag("FallCollider"))
        {
            _sceneLoader.RestartLevel();
        }

        if (other.CompareTag("Spikes"))
        {
            _sceneLoader.RestartLevel();
        }

        if (other.CompareTag("Fan"))
        {
            _sceneLoader.RestartLevel();
        }

    }
}
