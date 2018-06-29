using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxPickUp : PickUp {

    void Start() {
        amount = 25;
    }

    protected override void ApplyEffect(GameObject receiver) {
        receiver.GetComponent<PlayerController>().applyPickUp(this);
        Destroy(this);
    }

}
