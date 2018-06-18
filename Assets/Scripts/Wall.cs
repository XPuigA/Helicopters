using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, Hittable {
    public void Hit(GameObject toInstantiate) {
     //   throw new System.NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<Projectile>() != null) {
            other.gameObject.GetComponent<Projectile>().Visit(gameObject);
        }
    }
}
