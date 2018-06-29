using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Personage : MonoBehaviour, Hittable {

    public int baseLife;
    public int baseArmour;

    protected int maxLife;
    protected int maxArmour;

    protected int currentLife;
    protected int currentArmour;

    public Vector3 GetTilePosition() {
        RaycastHit2D hits;
        hits = Physics2D.Raycast(transform.position, Vector2.zero, 32f, 1 << LayerMask.NameToLayer("Ground"));
        if (hits && hits.collider.gameObject && hits.collider.gameObject.CompareTag("Floor")) {
            return hits.collider.gameObject.transform.position;
        }
        return Vector3.negativeInfinity;
    }

    public abstract void Hit(Projectile hitter);
}
