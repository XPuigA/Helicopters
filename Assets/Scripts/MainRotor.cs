using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRotor : Rotator
{

    public float speed = 45f;

    public override void Rotation()
    {
        transform.Rotate(new Vector3(0f, 0f, speed) * Time.deltaTime);
    }
}