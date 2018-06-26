using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public int numberOfTiles = 50;
    public GameObject player;
    public GameObject[] enemiesPrefabs;

    public GameObject[] enemies;

    public PathFindingStrategy pathFindingStrategy = new BFS();

    private LevelGenerator levelGenerator;
    private ObjectPlacer objectPlacer;
    private Dictionary<Vector3, Tile> map;

    void Start() {
        levelGenerator = new SimpleGenerator(floorTiles, wallTiles, numberOfTiles);
        
        map = levelGenerator.Generate();
        objectPlacer = new SimpleObjectPlacer(levelGenerator.GetTiles());

        objectPlacer.PlacePlayer(player);
        enemies = objectPlacer.PlaceEnemies(enemiesPrefabs, 1);
        List<Tile> path = getPath(enemies[0]);
        if (path.Count > 1) {
            path.Reverse();
            enemies[0].GetComponent<Enemy>().SetPath(path);
        }
    }

    void Update() {
    }

    private void hasPath(GameObject enemy) {
        Tile playerTile, enemyTile;

        map.TryGetValue(player.GetComponent<PlayerController>().GetTilePosition(), out playerTile);
        map.TryGetValue(enemy.GetComponent<Enemy>().GetTilePosition(), out enemyTile);

        Debug.Log(pathFindingStrategy.HasPath(map, enemyTile, playerTile));
    }

    private List<Tile> getPath(GameObject enemy) {
        Tile playerTile, enemyTile;

        map.TryGetValue(player.GetComponent<PlayerController>().GetTilePosition(), out playerTile);
        map.TryGetValue(enemy.GetComponent<Enemy>().GetTilePosition(), out enemyTile);

        List<Tile> path = pathFindingStrategy.FindPath(map, enemyTile, playerTile);

        return path;
    }
}
