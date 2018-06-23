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
        return doPathFinding(map, origin, destination, true);
    }

    private bool CanMove(Tile nextTile) {
        return true;
    }

    public bool HasPath(Dictionary<Vector3, Tile> map, Tile origin, Tile destination) {
        return doPathFinding(map, origin, destination, false).Count > 0;
    }


    private List<Tile> doPathFinding(Dictionary<Vector3, Tile> map, Tile origin, Tile destination, bool returnPath) {
        // key = position, value = from where we get there
        Dictionary<Vector3, Vector3> visited = new Dictionary<Vector3, Vector3>();
        Queue<Vector3> queue = new Queue<Vector3>();
        queue.Enqueue(origin.position);
        visited.Add(origin.position, new Vector3());
        while (queue.Count > 0) {
            Vector3 current = queue.Dequeue();
            if (current == destination.position) {
                List<Tile> path = new List<Tile>();
                if (returnPath) {
                    getFollowedPath(visited, origin, destination);
                }
                else {
                    path.Add(new Tile());
                }
                return path;
            }
            foreach (Vector3 direction in directions) {
                Vector3 next = current + direction;
                Tile nextTile;
                if (!visited.ContainsKey(next) && map.TryGetValue(next, out nextTile) && CanMove(nextTile)) {
                    visited.Add(next, current);
                    queue.Enqueue(next);
                }
            }
        }
        return new List<Tile>();
    }

    private void getFollowedPath(Dictionary<Vector3, Vector3> visited, Tile origin, Tile destination) {
        throw new NotImplementedException();
    }
}
