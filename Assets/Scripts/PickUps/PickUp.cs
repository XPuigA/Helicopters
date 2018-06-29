using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour {

    public int amount;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            ApplyEffect(collision.gameObject);
            Destroy(gameObject);
        }
    }

    protected abstract void ApplyEffect(GameObject receiver);
}
