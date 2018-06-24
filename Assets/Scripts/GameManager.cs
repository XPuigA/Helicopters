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
    private Dictionary<Vector3, Tile> map;

    void Start() {
        levelGenerator = new SimpleGenerator(floorTiles, wallTiles, numberOfTiles, player, enemy);
        map = levelGenerator.Generate();
        hasPath();
        List<Tile> path = getPath();
        enemy.GetComponent<Enemy>().SetDestination(path[0]);
    }

    void Update() {
        

    }

    private void hasPath() {
        Tile playerTile, enemyTile;

        map.TryGetValue(player.GetComponent<PlayerController>().GetTilePosition(), out playerTile);
        map.TryGetValue(enemy.GetComponent<Enemy>().GetTilePosition(), out enemyTile);

        Debug.Log(pathFindingStrategy.HasPath(map, enemyTile, playerTile));
    }

    private List<Tile> getPath() {
        Tile playerTile, enemyTile;

        map.TryGetValue(player.GetComponent<PlayerController>().GetTilePosition(), out playerTile);
        map.TryGetValue(enemy.GetComponent<Enemy>().GetTilePosition(), out enemyTile);

        List<Tile> path = pathFindingStrategy.FindPath(map, enemyTile, playerTile);

        foreach(Tile tile in path ) {
            Debug.Log("P:" + tile.position);
        }

        return path;
    }
}
