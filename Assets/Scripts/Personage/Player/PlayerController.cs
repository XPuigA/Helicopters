using System.Collections;
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

        currentLife = baseLife;
        maxLife = baseLife;
        currentArmour = 0;
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

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<Projectile>() != null) {
            other.gameObject.GetComponent<Projectile>().Visit(gameObject);
        }
    }

    public override void Hit(Projectile hitter) {
        Debug.Log("Hit " + hitter.Damage.ToString());
        Debug.Log("Killed: " + !TakeDamage(hitter.Damage));
    }

    public void applyPickUp(MedKitPickUp medKitPickUp) {
        Debug.Log("MEDKIT");
        currentLife += medKitPickUp.amount;
        if (currentLife > maxLife) {
            currentLife = maxLife;
        }
    }

    public void applyPickUp(BodyArmourPickUp bodyArmourPickUp) {
        Debug.Log("ARMOUR");
        currentArmour += bodyArmourPickUp.amount;
        if (currentArmour > maxArmour) {
            currentArmour = maxArmour;
        }
    }

    public void applyPickUp(AmmoBoxPickUp ammoBoxPickUp) {
        Debug.Log("AMMO");
    }
}
