using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform startPlatform = null;
    [SerializeField] private Transform levelPart_1 = null;
    
    private void Awake()
    {
        Transform lastLevelPartTranform;
      lastLevelPartTranform = SpwanLevelPart(startPlatform.Find("EndPosition").position);
      lastLevelPartTranform = SpwanLevelPart(lastLevelPartTranform.Find("EndPosition").position);
      
    }

    private Transform SpwanLevelPart(Vector3 spwanPosition)
    {
        Transform levelPart_1Clone = Instantiate(levelPart_1, spwanPosition, Quaternion.identity);
        levelPart_1Clone.transform.parent = GameObject.FindWithTag("WorldSpeed").transform;
        return levelPart_1Clone;

    }
}
