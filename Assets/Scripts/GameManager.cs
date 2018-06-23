using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject levelGeneratorGameObject;

    public PathFindingStrategy pathFindingStrategy = new BFS();

    bool found = false;

    private LevelGenerator levelGenerator;

    void Start() {
        levelGenerator = levelGeneratorGameObject.GetComponent<LevelGenerator>();
    }

    void Update() {
        Debug.Log(levelGenerator.map.Count);
        Debug.Log(levelGenerator.numberOfTiles);
        Debug.Log(levelGenerator.map.Count == levelGenerator.numberOfTiles);
        if (levelGenerator.map.Count == levelGenerator.numberOfTiles && !found) {
            Debug.Log("entra");
            Tile playerTile, enemyTile;
            levelGenerator.map.TryGetValue(levelGenerator.player.transform.position, out playerTile);
            levelGenerator.map.TryGetValue(levelGenerator.enemy.transform.position, out enemyTile);
            Debug.Log(pathFindingStrategy.HasPath(levelGenerator.map, enemyTile, playerTile));
            found = true;
        }
    }
}
