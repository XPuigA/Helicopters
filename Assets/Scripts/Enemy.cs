using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 GetTilePosition() {
        RaycastHit2D hits;
        hits = Physics2D.Raycast(transform.position, Vector2.zero, 32f, 1 << LayerMask.NameToLayer("Ground"));
        if (hits && hits.collider.gameObject && hits.collider.gameObject.CompareTag("Floor")) {
            return hits.collider.gameObject.transform.position;
        }
        return Vector3.negativeInfinity;
    }
}
