using UnityEngine;
using System.Collections;

public class EnemyMagic : MonoBehaviour {

    public float speed;


    void Start() {

    }


    void Update() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            collision.GetComponent<PlayerCollision>().ApplyDamage(3, transform.position);
            Destroy(gameObject);
        }
    }
}
