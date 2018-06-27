using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxPickUp : PickUp {

    protected override void ApplyEffect(GameObject receiver) {
        Debug.Log("AmmoBox");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
