using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LevelGenerator {

    Dictionary<Vector3, Tile> Generate();

    List<Vector3> GetTiles();
}
