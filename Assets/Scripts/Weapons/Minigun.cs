using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : GunController {

    public GameObject bullet;

    public override void Visit(GameObject other) {
        if (other.GetComponent<Hittable>() != null) {
            GameObject go = Instantiate(bullet, transform.position, Quaternion.identity);
            go.GetComponent<Projectile>().SetTarget(other);
        }
    }
}
