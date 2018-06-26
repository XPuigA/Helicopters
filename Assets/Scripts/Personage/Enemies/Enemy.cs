using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Personage {

    public float movementSpeed;
    public float rotationSpeed;

    private Vector3 destination = Vector3.negativeInfinity;
    private Rigidbody2D rb;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	void FixedUpdate () {
        if (!destination.Equals(Vector3.negativeInfinity)) {
            float x = Mathf.Abs(destination.x - transform.position.x);
            float y = Mathf.Abs(destination.y - transform.position.y);

            if (x > Mathf.Epsilon || y > Mathf.Epsilon) {
                Move();
                Rotate();
            }
            else {
                Debug.Log("E: " + transform.position);
                destination = Vector3.negativeInfinity;
            }
        }
	}

    void Move() {
        transform.position = Vector3.MoveTowards(transform.position, destination, 1f * Time.deltaTime * movementSpeed);        
    }

    void Rotate() {
        Vector3 diff = destination - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    public void SetDestination(Vector3 destination) {
        Debug.Log("Setting");
        this.destination = destination;
        Debug.Log("Destination " + this.destination);
    }

    public void SetDestination(Tile destination) {
        SetDestination(destination.position);
    }

    public override void Hit(Projectile hitter) {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<Projectile>() != null) {
            other.gameObject.GetComponent<Projectile>().Visit(gameObject);
        }
    }
}
