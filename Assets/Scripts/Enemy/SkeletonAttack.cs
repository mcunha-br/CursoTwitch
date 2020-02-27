using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour {

    public float strong = 10;


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            collision.GetComponent<PlayerCollision>().ApplyDamage(strong, transform.position);
        }
    }
}
