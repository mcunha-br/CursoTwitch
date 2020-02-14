using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public float jumpForce;
    public Rigidbody2D body;
    public Animator anim;
    public bool faceRight = true;
    public bool jump;
    public GameObject shootPrefab;
    public Transform barrel;


    private float horizontal;


    private void Update() {

        horizontal = Input.GetAxisRaw("Horizontal");


        if (horizontal > 0 && faceRight == false || horizontal < 0 && faceRight == true) {
            Flip();
        }
        

        if(Input.GetButtonDown("Jump")) {
            jump = true;
            anim.SetTrigger("jump");
        }

        if(Input.GetButtonDown("Fire1")) {
            Instantiate(shootPrefab, barrel.position, transform.rotation);
        }


        if(horizontal != 0) {
            anim.SetBool("walk", true);

        } else if(horizontal == 0) {
            anim.SetBool("walk", false);
        }
    }


    private void FixedUpdate() {
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);

        if (jump) {
            body.velocity = Vector2.zero;
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }


    private void Flip() {
        faceRight = !faceRight;

        if (faceRight) {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        } else {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
