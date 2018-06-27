using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ObjectPlacer {

    GameObject PlaceEnemy(GameObject enemy);

    GameObject[] PlaceEnemies(GameObject[] enemies, int numberOfEnemies);

    GameObject PlacePlayer(GameObject player);

    GameObject PlaceObject(GameObject objectToInstantiate);
}
