﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFS : PathFindingStrategy {

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
        Dictionary<Vector3, Vector3> visited = new Dictionary<Vector3, Vector3>(map.Count);
        Queue<Vector3> queue = new Queue<Vector3>();
        queue.Enqueue(origin.position);
        visited.Add(origin.position, Vector3.positiveInfinity);
        while (queue.Count > 0) {
            Vector3 current = queue.Dequeue();
            if (current == destination.position) {                
                List<Tile> path = new List<Tile>();
                if (returnPath) {
                    path = getFollowedPath(map, visited, origin, destination);
                }
                else {
                    path.Add(new Tile());
                }
                return path;
            }
            foreach (Vector3 direction in Directions.directions) {
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

    private List<Tile> getFollowedPath(Dictionary<Vector3, Tile> map, Dictionary<Vector3, Vector3> visited, Tile origin, Tile destination) {
        List<Tile> path = new List<Tile>();
        Vector3 nextPosition = destination.position;
        Tile nextTile;
        while (!nextPosition.Equals(Vector3.positiveInfinity)) {             
            visited.TryGetValue(nextPosition, out nextPosition);
            if (nextPosition.Equals(Vector3.positiveInfinity)) break;
            map.TryGetValue(nextPosition, out nextTile);
            path.Add(nextTile);
            nextPosition = nextTile.position;
        }
        return path;
    }
}
