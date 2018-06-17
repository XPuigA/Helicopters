using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public int numberOfTiles = 50;
    private float spriteSize;

    private List<Vector3> createdTiles = new List<Vector3>();
    private Transform parent;

	// Use this for initialization
	void Start () {
        spriteSize = floorTiles[0].GetComponent<SpriteRenderer>().bounds.size.x;
        parent = new GameObject("Level").transform;
        StartCoroutine("Generate");
        
	}
	
    void Generate() {
        GenerateFloor();
        GenerateWalls();
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
            GameObject go = Instantiate(floorTiles[Random.Range(0, floorTiles.Length)], transform.position, Quaternion.identity, parent);
            createdTiles.Add(transform.position);
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
        float extraWallX = 5;
        float extraWallY = 5;

        foreach (Vector3 vector in createdTiles) {
            if (vector.x > maxX) maxX = vector.x;
            if (vector.x < minX) minX = vector.x;
            if (vector.y > maxY) maxY = vector.y;
            if (vector.y < minY) minY = vector.y;
        }

        xAmount = ((maxX - minX) / spriteSize) + extraWallX;
        yAmount = ((maxY - minY) / spriteSize) + extraWallY;
        
        for (int x = 0; x < xAmount; x++) {
            for (int y = 0; y < yAmount; y++) {
                Vector3 pos = new Vector3((minX - (extraWallX * spriteSize) / 2) + (x * spriteSize), (minY - (extraWallY * spriteSize) / 2) + (y * spriteSize), 0f);
                if (!createdTiles.Contains(pos)) {
                    Instantiate(wallTiles[Random.Range(0, wallTiles.Length)], pos, Quaternion.identity, parent);
                }
            }
        }
    }

    
}
