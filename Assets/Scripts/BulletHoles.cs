using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoles : MonoBehaviour {

    public List<Sprite> sprites;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = getRandomSprite();
	}

    private Sprite getRandomSprite()
    {
        return sprites[Random.Range(0, sprites.Count)];
    }
}
