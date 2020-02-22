using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy {

    public float speed;
    public Transform pointMagic;
    public GameObject magic;

    private Transform player;
    private Vector3 target;
    private Vector3 startPostision;
    private bool faceRight = true;
    private Animator anim;
    private float speedCurrent;
    private bool inAttack;

    protected new void Start() {
        base.Start();
        player = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        startPostision = transform.position;
        speedCurrent = speed;
    }

    
    void Update() {

        var distance = Vector2.Distance(transform.position, player.position);
        transform.position = Vector2.MoveTowards(transform.position, target, speedCurrent * Time.deltaTime);        

        if(distance <= 5) {
            target = player.position;

            if (distance <= 1 && !inAttack) {
                inAttack = true;
                Attack();
            }

        } else {
            target = startPostision;
        }

        if (transform.position.x > target.x && faceRight || transform.position.x < target.x && !faceRight)
            Flip();

        anim.SetFloat("movement", Vector2.Distance(transform.position, target));
    }


    private void Attack() {
        //var rand = Random.Range(0, 100);
        //if (rand <= 50)
        //    anim.Play("attack");
        //else
            anim.Play("magia");

        speedCurrent = 0;
    }



    private void Flip() {
        if (inAttack) return;

        faceRight = !faceRight;

        transform.rotation = (faceRight) ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);        
    }

    public void RestoreSpeed() {
        inAttack = false;
        speedCurrent = speed;
    }

    public void InvokeMagic() {
        Instantiate(magic, pointMagic.position, transform.rotation);
    }
}
