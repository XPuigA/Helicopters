using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailRotor : Rotator {

    public float speed = 45f;

    public override void Rotation() {
        transform.Rotate(new Vector3(0f, speed, 0f) * Time.deltaTime);
    }
}
