using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

    private PlayerController pController;
    private float health => pController.health;
    private Rigidbody2D body;

    private void Start() {
        pController = GetComponent<PlayerController>();
        body = GetComponent<Rigidbody2D>();
    }

    public void ApplyDamage(float damage, Vector3 direction) {
        pController.health -= damage;
        if (!pController.death && health > 0) {
            StartCoroutine("Damage", direction);
        }
    }

    private IEnumerator Damage(Vector3 direction) {
        pController.enabled = false;

        var strong = (direction.x < transform.position.x) ? 3 : -3;

        body.AddForce(new Vector2(strong, 3.5f), ForceMode2D.Impulse);
        Debug.Log(strong);
        yield return new WaitForSeconds(.5f);
        pController.enabled = true;
    }
}
