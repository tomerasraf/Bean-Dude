using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform startPlatform = null;
    [SerializeField] private Transform levelPart_1 = null;
    [SerializeField] private Player _player = null;
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 150f;
    private Vector3 lastEndPosition;
    private void Awake()
    {
        lastEndPosition = startPlatform.Find("EndPosition").position;
        for (int i = 0; i < 5; i++)
        {
            SpwanLevelPart();
        }
    }
    private void Update()
    {
        float distance = Vector3.Distance(lastEndPosition, _player.transform.position);

        if (distance < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpwanLevelPart();
        }
    }

    private void SpwanLevelPart()
    {
        Transform lastLevelPartTransform = SpwanLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpwanLevelPart(Vector3 spwanPosition)
    {
        Transform levelPart_1Clone = Instantiate(levelPart_1, spwanPosition, Quaternion.identity);
        levelPart_1Clone.transform.parent = GameObject.Find("Level_1Objects").transform; 
        return levelPart_1Clone;

    }


}
