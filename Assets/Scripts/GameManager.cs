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
        hasPath();
        getPath();
    }

    void Update() {
        

    }

    private void hasPath() {
        Tile playerTile, enemyTile;

        levelGenerator.map.TryGetValue(player.GetComponent<PlayerController>().GetTilePosition(), out playerTile);
        levelGenerator.map.TryGetValue(enemy.GetComponent<Enemy>().GetTilePosition(), out enemyTile);

        Debug.Log(pathFindingStrategy.HasPath(levelGenerator.map, enemyTile, playerTile));
    }

    private void getPath() {
        Tile playerTile, enemyTile;

        levelGenerator.map.TryGetValue(player.GetComponent<PlayerController>().GetTilePosition(), out playerTile);
        levelGenerator.map.TryGetValue(enemy.GetComponent<Enemy>().GetTilePosition(), out enemyTile);

        List<Tile> path = pathFindingStrategy.FindPath(levelGenerator.map, enemyTile, playerTile);

        foreach(Tile tile in path ) {
            Debug.Log("P:" + tile.position);
        }
    }
}
