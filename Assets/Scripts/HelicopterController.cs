using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour {

    public float movementSpeed;
    public float rotationSpeed;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        rb.AddForce(movement * movementSpeed);
        
        if (Input.GetKey(KeyCode.Q)) {
            transform.Rotate(new Vector3(0f, 0f, rotationSpeed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E)) {
            transform.Rotate(new Vector3(0f, 0f, -rotationSpeed) * Time.deltaTime);
        }
    }
}
