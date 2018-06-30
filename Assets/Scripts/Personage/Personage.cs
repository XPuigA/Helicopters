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

    public bool alive = true;

    public Vector3 GetTilePosition() {
        RaycastHit2D hits;
        hits = Physics2D.Raycast(transform.position, Vector2.zero, 32f, 1 << LayerMask.NameToLayer("Ground"));
        if (hits && hits.collider.gameObject && hits.collider.gameObject.CompareTag("Floor")) {
            return hits.collider.gameObject.transform.position;
        }
        return Vector3.negativeInfinity;
    }

    public abstract void Hit(Projectile hitter);

    public void Kill() {
        alive = false;
        Destroy(gameObject);
    }

    public bool TakeDamage(float damage) {
        float remainingDamage = damage - currentArmour;
        if (currentArmour > 0) {
            currentArmour -= (int)Mathf.Round(damage - remainingDamage);
        }
        if (remainingDamage > 0) {
            currentLife -= (int)Mathf.Round(remainingDamage);
        }
        if (currentLife <= 0) {
            Kill();
            return false;
        }
        return true;
    }
}
