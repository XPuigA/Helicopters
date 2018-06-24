using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGenerator : LevelGenerator {

    private GameObject[] floorTiles;
    private GameObject[] wallTiles;
    private int numberOfTiles = 50;
    private GameObject player;
    private GameObject enemy;

    private float spriteSize;
    private List<Vector3> createdTiles;

    [HideInInspector]
    private Transform parent;
    private Dictionary<Vector3, Tile> map;
    private Vector3 position = Vector3.zero;

    public SimpleGenerator(GameObject[] floorTiles, GameObject[] wallTiles, int numberOfTiles, GameObject player, GameObject enemy) {
        this.floorTiles = floorTiles;
        this.wallTiles = wallTiles;
        this.numberOfTiles = numberOfTiles;
        this.player = player;
        this.enemy = enemy;

        createdTiles = new List<Vector3>(numberOfTiles);
        map = new Dictionary<Vector3, Tile>(numberOfTiles);
        spriteSize = (floorTiles[0].GetComponent<SpriteRenderer>().bounds.size.x);
        parent = new GameObject("Level").transform;
        //Generate();
    }

    public Dictionary<Vector3, Tile> Generate() {
        GenerateFloor();
        GenerateWalls();
        AddPlayer();
        AddEnemy();
        return map;
    }

    private void AddPlayer() {
        Vector3 pos = createdTiles[Random.Range(0, createdTiles.Count)];
        player.transform.position = pos;
    }

    private void AddEnemy() {
        Vector3 pos = createdTiles[Random.Range(0, createdTiles.Count)];
        enemy.transform.position = pos;
    }

    private void GenerateFloor() {
        for (int i = 0; i < numberOfTiles; i++) {
            int dir = Random.Range(0, 4);
            SetTile(dir);
        }
    }

    private void SetTile(int dir) {
        Vector3 curPos = position;
        switch (dir) {
            case 0:
                position = new Vector3(curPos.x, curPos.y + spriteSize, curPos.z);
                break;
            case 1:
                position = new Vector3(curPos.x + spriteSize, curPos.y, curPos.z);
                break;
            case 2:
                position = new Vector3(curPos.x, curPos.y - spriteSize, curPos.z);
                break;
            case 3:
                position = new Vector3(curPos.x - spriteSize, curPos.y, curPos.z);
                break;
        }
        if (!createdTiles.Contains(position)) {
            CreateTile();
        }
        else {
            numberOfTiles++;
        }
    }

    private void CreateTile() {
        GameObject go = (GameObject)GameObject.Instantiate(floorTiles[Random.Range(0, floorTiles.Length)], position, Quaternion.identity, parent);
        createdTiles.Add(go.transform.position);
        map.Add(position, new Tile(position, go));
    }

    private void GenerateWalls() {
        float maxX = 0;
        float minX = 999999;
        float maxY = 0;
        float minY = 999999;
        float xAmount;
        float yAmount;
        float extraWallX = 6;
        float extraWallY = 6;

        foreach (Vector3 vector in createdTiles) {
            if (vector.x > maxX) maxX = vector.x;
            if (vector.x < minX) minX = vector.x;
            if (vector.y > maxY) maxY = vector.y;
            if (vector.y < minY) minY = vector.y;
        }

        xAmount = ((maxX - minX) / spriteSize) + extraWallX;
        yAmount = ((maxY - minY) / spriteSize) + extraWallY;

        for (float x = 0; x < xAmount; x++) {
            for (float y = 0; y < yAmount; y++) {
                Vector3 pos = new Vector3((minX - (extraWallX * spriteSize) / 2f) + (x * spriteSize), (minY - (extraWallY * spriteSize) / 2f) + (y * spriteSize));
                if (!createdTiles.Contains(pos)) {
                    GameObject.Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], pos, Quaternion.identity, parent);
                }
            }
        }
    }
}
