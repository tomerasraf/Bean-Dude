using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] Transform playerTranform = null;
    [SerializeField] GameObject[] platfromsPrefabs = null;

    ParticleSystem beanParticle;
    public GameObject platformCopy;
    private List<GameObject> activePlatfroms = new List<GameObject>();
    float zSpwan = 0;
    float platformLength = 60;
    int numberOfPlatforms = 5;
    int safeZone = 130;

    private void Awake()
    {

    }

    private void Start()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            if (i == 0)
                SpwanPlatform(0);
            else
                SpwanPlatform(Random.Range(0, platfromsPrefabs.Length));
        }
    }

    private void Update()
    {
        if (playerTranform.position.z - safeZone > zSpwan - (numberOfPlatforms * platformLength))
        {
            SpwanPlatform(Random.Range(0, platfromsPrefabs.Length));
            DeletePlatform();
        }
    }

    public void SpwanPlatform(int platformIndex)
    {
        platformCopy = Instantiate(platfromsPrefabs[platformIndex], transform.forward * zSpwan, Quaternion.identity);
        activePlatfroms.Add(platformCopy);
        zSpwan += platformLength;
    }

    private void DeletePlatform()
    {
        Destroy(activePlatfroms[0]);
        activePlatfroms.RemoveAt(0);
    }
}
