using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour, Hittable {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Stay");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit");
        if (other.gameObject.GetComponent<GunController>() != null)
        {
            other.gameObject.GetComponent<GunController>().Visit(gameObject);
        }
    }

    public void Hit(GameObject toInstantiate)
    {
        Instantiate(toInstantiate, transform);
    }

}
