using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {

    public GameObject bulletHole;
    protected GameObject target;
    public float speed;

    private void Start()
    {
        
    }

    void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }

    public void Visit(GameObject other)
    {
        if (other.GetComponent<Hittable>() != null)
        {
            other.GetComponent<Hittable>().Hit(bulletHole);
            Destroy(gameObject);
        }
    }

    public void SetTarget(GameObject target)
    {
        Debug.Log("Target setted " + target.tag);
        this.target = target;
    }
}
