using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {

    public GameObject bulletHole;
    protected Vector3 target = Vector3.negativeInfinity;
    public float speed;

    private void Start()
    {
        
    }

    void Update () {
        if (!target.Equals(Vector3.negativeInfinity))
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
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

    public void SetTarget(GameObject target)
    {
        SetTarget(target.transform);
    }

    public void SetTarget(Transform target)
    {
        SetTarget(target.position);
    }

    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }
}
