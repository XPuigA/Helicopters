using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public int numberOfTiles = 50;
    public GameObject player;

    private float spriteSize;
    private List<Vector3> createdTiles = new List<Vector3>();
    private Transform parent;

	// Use this for initialization
	void Start () {
        spriteSize = (floorTiles[0].GetComponent<SpriteRenderer>().bounds.size.x);
        Debug.Log(spriteSize);
        parent = new GameObject("Level").transform;
        StartCoroutine("Generate");
	}
	
    void Generate() {
        GenerateFloor();
        GenerateWalls();
        AddPlayer();
    }

    private void AddPlayer() {
        Vector3 pos = createdTiles[Random.Range(0, createdTiles.Count)];
        player.transform.position = pos;
    }

    private void GenerateFloor() {
        for (int i=0; i<numberOfTiles; i++) {
            int dir = Random.Range(0, 4);
            SetTile(dir);
        }
    }

    private void SetTile(int dir) {
        Vector3 curPos = transform.position;
        switch (dir) {            
            case 0:
                transform.position = new Vector3(curPos.x, curPos.y + spriteSize, curPos.z);
                break;
            case 1:
                transform.position = new Vector3(curPos.x + spriteSize, curPos.y, curPos.z);
                break;
            case 2:
                transform.position = new Vector3(curPos.x, curPos.y - spriteSize, curPos.z);
                break;
            case 3:
                transform.position = new Vector3(curPos.x - spriteSize, curPos.y, curPos.z);
                break;
        }
        if (!createdTiles.Contains(transform.position)) {
            GameObject go = (GameObject)Instantiate(floorTiles[Random.Range(0, floorTiles.Length)], transform.position, transform.rotation, parent);
            createdTiles.Add(go.transform.position);
        }
        else {
            numberOfTiles++;
        }
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
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], pos, transform.rotation, parent);
                }
            }
        }
    }

    
}
