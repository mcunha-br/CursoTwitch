using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

    private PlayerController pController;
    private Rigidbody2D body;

    private void Start() {
        pController = GetComponent<PlayerController>();
        body = GetComponent<Rigidbody2D>();
    }

    public void ApplyDamage(float damage, Vector3 direction) {
        pController.Health -= damage;
        if (!pController.death && pController.Health > 0) {
            StartCoroutine("Damage", direction);
        }
    }

    private IEnumerator Damage(Vector3 direction) {
        pController.enabled = false;

        var strong = (direction.x < transform.position.x) ? 3 : -3;

        body.AddForce(new Vector2(strong, 3.5f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(.5f);
        pController.enabled = true;
    }
}
