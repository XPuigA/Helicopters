﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Personage {

    public float movementSpeed;
    private Rigidbody2D rb;
    private Animator animator;
    public GameObject weapon;
    private SpriteRenderer spriteRenderer;
    private Weapon mainWeapon;

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
        mainWeapon = weapon.gameObject.GetComponent<Weapon>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
        rb.velocity = (movement * movementSpeed);
        
        if (Mathf.Abs(movement.x) > 0 || Mathf.Abs(movement.y) > 0) {
            animator.SetTrigger("TriggerMove");
        }
        else {
            animator.SetTrigger("TriggerIdle");
        }
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetMouseButtonDown(0)) {
            mainWeapon.ShootAtMouseDirection(transform.position);
            animator.SetTrigger("TriggerShoot");
        }
    }

    public override void Hit(GameObject toInstantiate) {
        throw new System.NotImplementedException();
    }
}