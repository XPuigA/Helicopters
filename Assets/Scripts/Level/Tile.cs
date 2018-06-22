using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

    public Vector3 position;
    readonly GameObject gameObject;

	Tile() {

    }

    public Tile(Vector3 position) {
        this.position = position;
    }

    public Tile(Vector3 position, GameObject gameObject) {
        this.position = position;
        this.gameObject = gameObject;
    }

    public override bool Equals(object obj) {
        var tile = obj as Tile;
        return tile != null &&
               EqualityComparer<Vector3>.Default.Equals(position, tile.position);
    }

    public override int GetHashCode() {
        var hashCode = -1380947426;
        hashCode = hashCode * -1521134295 + EqualityComparer<Vector3>.Default.GetHashCode(position);
        return hashCode;
    }
}
