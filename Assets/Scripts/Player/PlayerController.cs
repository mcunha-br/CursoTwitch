﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpForce;
    private float health = 50;
    public int doubleJump = 2;
    public GameObject shootPrefab;
    public Transform barrel;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    private Rigidbody2D body;
    private Animator anim;
    private UIGamePlayer uIGamePlayer;
    private bool faceRight = true;
    private bool jump;
    private bool isGround;
    private int amountJump;
    public bool death { get; set; }

    private float horizontal;


    public float Health {
        get => health;
        set {
            health = value;
            uIGamePlayer.health.value = health;
            if(health <= 0) {
                death = true;
            }
        }
    }


    private void Start() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        uIGamePlayer = FindObjectOfType<UIGamePlayer>();
        Health = 50;

        amountJump = doubleJump;

    }


    private void Update() {

        horizontal = Input.GetAxisRaw("Horizontal");
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.02f, whatIsGround);


        if (horizontal > 0 && faceRight == false || horizontal < 0 && faceRight == true) {
            Flip();
        }
        

        if(Input.GetButtonDown("Jump") && amountJump > 1) {
            jump = true;
            amountJump--;
            anim.SetTrigger("jump");
        }

        if (isGround)
            amountJump = doubleJump;

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
