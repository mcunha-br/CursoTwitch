using UnityEngine;
using System.Collections;

public class EnemyPatrol : Enemy {

    public float speed;
    public Transform groundCheck;
    public LayerMask whatsIsGround;

    private Rigidbody2D body;
    private bool isGround;
    private bool faceRight = true;



    private new void Start() {
        base.Start();
        body = GetComponent<Rigidbody2D>();
    }


    private void Update() {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.02f, whatsIsGround);

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (!isGround)
            Flip();
    }

    private void Flip() {
        faceRight = !faceRight;

        if (faceRight)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }


    protected override void OnDeath() {
        Destroy(gameObject);
    }
}
