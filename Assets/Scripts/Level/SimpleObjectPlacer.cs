using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPlacer : ObjectPlacer {

    private List<Vector3> tiles;
    private Dictionary<Vector3, Tile>.ValueCollection values;

    public SimpleObjectPlacer(List<Vector3> tiles) {
        this.tiles = new List<Vector3>(tiles);
    }

    public GameObject[] PlaceEnemies(GameObject[] enemies, int numberOfEnemies) {
        GameObject[] generatedEnemies = new GameObject[numberOfEnemies];
        for (int i=0; i<numberOfEnemies; i++) {
            generatedEnemies[i] = PlaceEnemy(enemies[Random.Range(0, enemies.Length)]);
        }
        return generatedEnemies;
    }

    public GameObject PlaceEnemy(GameObject enemy) {
        Vector3 pos = this.tiles[Random.Range(0, this.tiles.Count)];
        GameObject generatedEnemy = GameObject.Instantiate(enemy, pos, Quaternion.identity);
        tiles.Remove(pos);
        return generatedEnemy;
        
    }

    public GameObject PlacePlayer(GameObject player) {
        Vector3 pos = this.tiles[Random.Range(0, this.tiles.Count)];
        player.transform.position = pos;
        tiles.Remove(pos);
        return player;
    }
}
