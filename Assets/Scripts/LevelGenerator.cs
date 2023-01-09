using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 1f;

    [SerializeField] public TileMetrics levelPart_Start;
    [SerializeField] public List<TileMetrics> levelPartList;
    private Queue<TileMetrics> generatedLevels;
    [SerializeField] public GameObject player;

    private Vector3 lastEndPosition;

    private void Awake() {
        lastEndPosition = levelPart_Start.endPosition;

        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++) {
            SpawnLevelPart();
        }
    }

    private void Update() {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART) {
            // Spawn another level part
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart() {
        TileMetrics chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        TileMetrics lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.endPosition;
        Debug.Log(lastEndPosition);
    }

    private TileMetrics SpawnLevelPart(TileMetrics levelPart, Vector3 spawnPosition) {
        TileMetrics levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

}
