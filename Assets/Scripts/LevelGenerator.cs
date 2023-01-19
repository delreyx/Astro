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

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag != "Player") return;
        SpawnLevelPart();
    }

    private void SpawnLevelPart() {
        TileMetrics chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        TileMetrics lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.endPosition;
        transform.position = lastEndPosition;
    }

    private TileMetrics SpawnLevelPart(TileMetrics levelPart, Vector3 spawnPosition) {
        TileMetrics levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

}
