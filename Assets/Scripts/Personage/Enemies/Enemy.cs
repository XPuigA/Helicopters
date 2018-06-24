using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Personage, Hittable {

    // Use this for initialization
    public float movementSpeed;

    private Vector3 destination = Vector3.negativeInfinity;
    private Rigidbody2D rb;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!destination.Equals(Vector3.negativeInfinity)) {
            float x = Mathf.Abs(destination.x - transform.position.x);
            float y = Mathf.Abs(destination.y - transform.position.y);

            if (x > Mathf.Epsilon || y > Mathf.Epsilon) {
                Move();
            }
            else {
                Debug.Log("E: " + transform.position);
                destination = Vector3.negativeInfinity;
            }
        }
	}

    void Move() {

        Debug.Log("Entra " + destination);
        //transform.LookAt(destination);
        Debug.Log((transform.position - destination).normalized);
        rb.velocity = (((destination - transform.position).normalized) * movementSpeed);
        //rb.MovePosition(transform.position - destination * Time.deltaTime);
    }


    public void SetDestination(Vector3 destination) {
        Debug.Log("Setting");
        this.destination = destination;
        Debug.Log("Destination " + this.destination);
    }

    public void SetDestination(Tile destination) {
        SetDestination(destination.position*2);
    }

    public override void Hit(GameObject toInstantiate) {
        throw new System.NotImplementedException();
    }
}
