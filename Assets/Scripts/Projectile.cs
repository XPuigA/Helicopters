using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {

    public GameObject bulletHole;
    protected Vector3 target = Vector3.negativeInfinity;

    private Rigidbody2D rb;
    private float speed;
    private Vector2 direction;

    public float Damage { get; set; }

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update () {
        if (!target.Equals(Vector3.negativeInfinity))
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
        else {
            this.GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    public void Visit(GameObject other)
    {
        if (other.GetComponent<Hittable>() != null)
        {
            other.GetComponent<Hittable>().Hit(this);
            Destroy(gameObject);
        }
    }

    public void Initialize(GameObject target, float speed, float damage) {
        Initialize(target.transform, speed, damage);
        
    }

    public void Initialize(Transform target, float speed, float damage) {
        Initialize(target.position, speed, damage);
    }

    public void Initialize(Vector3 target, float speed, float damage) {
        SetTarget(target);
        
    }

    public void Initialize(float speed, float damage) {
        this.Damage = damage;
        this.speed = speed;
    }

    public void Initialize(Vector2 direction, float speed, float damage) {
        Initialize(speed, damage);
        this.direction = direction;
    }

    public void SetTarget(GameObject target) {
        SetTarget(target.transform);
    }

    public void SetTarget(Transform target) {
        SetTarget(target.position);
    }

    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }
}
