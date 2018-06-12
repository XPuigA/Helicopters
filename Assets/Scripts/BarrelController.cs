using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour, Hittable {

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        toInstantiate = Instantiate(toInstantiate, transform);
        SpriteRenderer toInstantiateRenderer = toInstantiate.GetComponent<SpriteRenderer>();
        float sizeX = spriteRenderer.bounds.size[0] - toInstantiateRenderer.bounds.size[0];
        float sizeY = spriteRenderer.bounds.size[1] - toInstantiateRenderer.bounds.size[1];
        float x = Random.Range(-sizeX, sizeX);
        float y = Random.Range(-sizeY, sizeY);

        toInstantiate.transform.localPosition = new Vector3(x, y, 0f);
        
    }

}
