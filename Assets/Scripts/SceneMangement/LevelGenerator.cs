using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform startPlatform = null;
    [SerializeField] private List<Transform> levelPartList = null;
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
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpwanLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpwanLevelPart(Transform levelPart, Vector3 spwanPosition)
    {
        Vector3 SpwanOffset = new Vector3(spwanPosition.x, spwanPosition.y, 100f);
        Transform levelPart_Clone = Instantiate(levelPart, spwanPosition + SpwanOffset, Quaternion.identity);
        // levelPart_1Clone.transform.parent = GameObject.Find("Level_1Objects").transform;
        return levelPart_Clone;

    }


}
