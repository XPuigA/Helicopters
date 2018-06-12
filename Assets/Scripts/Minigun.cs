using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : GunController {

    public GameObject bulletHole;

    public override void Visit(GameObject other)
    {
        if (other.GetComponent<Hittable>() != null)
        {
            other.GetComponent<Hittable>().Hit(bulletHole);
        }
        
    }
}
