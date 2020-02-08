using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Shoot")) {
            health -= 1;

            Destroy(collision.gameObject);

            if (health <= 0)
                Destroy(gameObject);
        }
    }
}
