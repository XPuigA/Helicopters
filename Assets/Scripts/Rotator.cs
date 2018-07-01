using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rotator : MonoBehaviour
{
    void FixedUpdate() {
        Rotation();
    }

    public abstract void Rotation();
}