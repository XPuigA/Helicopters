using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PathFindingStrategy {

    bool HasPath(Dictionary<Vector3, Tile> map, Tile origin, Tile destination);

    List<Tile> FindPath(Dictionary<Vector3, Tile> map, Tile origin, Tile destination);
}
