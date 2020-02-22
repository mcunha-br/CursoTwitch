using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;

    private SpriteRenderer sprite;

    protected void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Shoot")) {
            health -= 1;

            StartCoroutine("Hit");

            Destroy(collision.gameObject);

            if (health <= 0)
                Destroy(gameObject);
        }
    }


    private IEnumerator Hit() {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }
}
