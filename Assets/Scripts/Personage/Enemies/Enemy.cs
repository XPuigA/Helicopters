using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Personage, Hittable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Move() {

    }

    public override void Hit(GameObject toInstantiate) {
        throw new System.NotImplementedException();
    }
}
