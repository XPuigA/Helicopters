using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float speed;
    public GameObject projectile;

	public void ShootAt(GameObject target)
    {
        ShootAt(target.transform);
    }

    public void ShootAt(Transform target)
    {
        ShootAt(target.position);
    }

    public void ShootAt(Vector3 target)
    {
        GameObject go = Instantiate(projectile, transform.position, Quaternion.identity);
        go.GetComponent<Projectile>().SetTarget(target);
    }

    public void ShootAtMouseDirection(Vector3 origin)
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (Vector2)((worldMousePos - origin));
        direction.Normalize();
        // Creates the bullet locally
        GameObject bullet = (GameObject)Instantiate(
                                projectile,
                                origin + (Vector3)(direction * 0.5f),
                                Quaternion.identity);
        // Adds velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
