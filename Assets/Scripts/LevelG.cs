using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;


public class LevelG : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;
    [SerializeField] public Transform levelpartStart;
    [SerializeField] public List<Transform> levelpartList;
    private Vector3 lastEndPosition;
    [SerializeField] public PlayerPlatformerController player;
    // Start is called before the first frame update
    public void Awake()
    {
        lastEndPosition = levelpartStart.Find("EndPosition").position;
      
        int startingSpawnLevelParts = 5;
        for(int i = 0; i < startingSpawnLevelParts; i++)
        {
            spawnLevelPart();
        }
    }
    private void Update()
    {
        if (Vector3.Distance(player.GetPosition(), lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            spawnLevelPart();
        }
    }
    private void spawnLevelPart()
    {
        Transform chosenLevelPart = levelpartList[Random.Range(0, levelpartList.Count)];
       Transform lastLevelPartTransform= SpawnLevel(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevel(Transform levelPart,Vector3 spawnPosition)
    {
      Transform levelPartTransform= Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
