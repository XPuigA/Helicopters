using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Directions {

    public static Vector3 UP = new Vector3(0f, 32f);
    public static Vector3 DOWN = new Vector3(0f, -32f);
    public static Vector3 LEFT = new Vector3(-32f, 0f);
    public static Vector3 RIGHT = new Vector3(32f, 0f);

    public static Vector3[] directions = { UP, RIGHT, DOWN, LEFT };

}
