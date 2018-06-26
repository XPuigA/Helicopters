﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Personage {

    public float movementSpeed;
    public GameObject weapon;
    public GameObject soundManagerGameObject;
    public AudioClip stepsSound;
    public AudioClip shootSound;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Weapon mainWeapon;
    private AudioSource soundManager;
    

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
        mainWeapon = weapon.gameObject.GetComponent<Weapon>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        soundManager = soundManagerGameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
        rb.velocity = (movement * movementSpeed);
        
        if (Mathf.Abs(movement.x) > 0 || Mathf.Abs(movement.y) > 0) {
            animator.SetTrigger("TriggerMove");
            
            soundManager.clip = stepsSound;
            soundManager.Play();
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
            
            soundManager.clip = shootSound;
            soundManager.Play();
        }
    }

    public override void Hit(Projectile hitter) {
        throw new System.NotImplementedException();
    }
}
