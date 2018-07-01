using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Personage {

    public float movementSpeed;
    public float rotationSpeed;
    public GameObject weaponGameObject;

    public float sightDistance;
    public float weaponCooldownTime;

    private GameObject player;
    private Weapon weapon;
    private Vector3 destination = Vector3.negativeInfinity;
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;
    private List<Vector3> path = new List<Vector3>();

    private float time = 0;

    void Start () {
        maxLife = baseLife;
        maxArmour = baseArmour;
        currentLife = baseLife;
        currentArmour = 0;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        weapon = weaponGameObject.gameObject.GetComponent<Weapon>();
        player = GameManager.instance.player;
}
	
	void FixedUpdate () {
        if (alive) {
            Move();
            Rotate();
            Shoot();
        }
    }

    void Move() {
        if (!destination.Equals(Vector3.negativeInfinity)) {
            float x = Mathf.Abs(destination.x - transform.position.x);
            float y = Mathf.Abs(destination.y - transform.position.y);

            if (x > Mathf.Epsilon || y > Mathf.Epsilon) {
                transform.position = Vector3.MoveTowards(transform.position, destination, 1f * Time.deltaTime * movementSpeed);
            }
            else {              
              destination = Vector3.negativeInfinity;
            }
        }
        if (path.Count > 0 && destination.Equals(Vector3.negativeInfinity)) {
            SetDestination(path[0]);
            path.RemoveAt(0);
        }
    }

    void Rotate() {
        Vector3 diff = destination - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        if (!float.IsNaN(rot_z)) {
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }

    protected bool PlayerInSight() {
        circleCollider.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized, sightDistance, 1 << LayerMask.NameToLayer("ColliderLayer"));
        circleCollider.enabled = true;

        if (hit && hit.transform.gameObject.CompareTag("Player")) {
            return true;
        }
        return false;
    }

    void Shoot() {
        if (PlayerInSight() && time <= 0) {
            time = weaponCooldownTime;
            Vector2 direction = (Vector2)((player.transform.position - transform.position));
            direction.Normalize();
            weapon.ShootAtDirection(transform.position, direction);
        }
        else if (time > 0) time-= Time.fixedDeltaTime;
    }

    public void SetDestination(Vector3 destination) {
        this.destination = destination;
    }

    public void SetDestination(Tile destination) {
        SetDestination(destination.position);
    }

    public void SetPath(List<Tile> path) {
        List<Vector3> vectorPath = new List<Vector3>();
        foreach (Tile tile in path) {
            vectorPath.Add(tile.position);
        }
        SetPath(vectorPath);
    }

    public void SetPath(List<Vector3> path) {
        this.path = path;
    }

    public override void Hit(Projectile hitter) {
        TakeDamage(hitter.Damage);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<Projectile>() != null) {
            other.gameObject.GetComponent<Projectile>().Visit(gameObject);
        }
    }
}
