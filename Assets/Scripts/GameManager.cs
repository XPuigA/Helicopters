using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public int numberOfTiles = 50;
    public GameObject player;
    public GameObject enemy;

    public PathFindingStrategy pathFindingStrategy = new BFS();

    private LevelGenerator levelGenerator;

    void Start() {
        levelGenerator = new LevelGenerator(floorTiles, wallTiles, numberOfTiles, player, enemy);
    }

    void Update() {
        Tile playerTile, enemyTile;

        levelGenerator.map.TryGetValue(player.transform.position, out playerTile);
        levelGenerator.map.TryGetValue(enemy.transform.position, out enemyTile);

        Debug.Log(pathFindingStrategy.HasPath(levelGenerator.map, enemyTile, playerTile));

    }
}
