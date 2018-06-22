using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFS : PathFindingStrategy {

    Vector3[] directions = {
        new Vector3(0f, 1f),
        new Vector3(1f, 0f),
        new Vector3(0f, -1f),
        new Vector3(-1f, 0f)
    };

    public List<Tile> FindPath(Dictionary<Vector3, Tile> map, Tile origin, Tile destination) {
        HashSet<Vector3> visited = new HashSet<Vector3>();
        Queue<Vector3> queue = new Queue<Vector3>();
        queue.Enqueue(origin.position);
        visited.Add(origin.position);
        while(queue.Count > 0) {
            Vector3 current = queue.Dequeue();
            if (current == destination.position) {
                // TODO find the path
                return new List<Tile>(); 
            }
            foreach (Vector3 direction in directions) {
                Vector3 next = current + direction;
                Tile nextTile;
                if (!visited.Contains(next) && map.TryGetValue(next, out nextTile) && CanMove(nextTile)) {
                    visited.Add(next);
                    queue.Enqueue(next);
                }
            }
        }
        return new List<Tile>();
    }

    private bool CanMove(Tile nextTile) {
        return true;
    }

    public bool HasPath(Dictionary<Vector3, Tile> map, Tile origin, Tile destination) {
        return FindPath(map, origin, destination).Count > 0;
    }
}
