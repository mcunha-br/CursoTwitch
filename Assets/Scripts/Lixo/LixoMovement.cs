using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixoMovement : MonoBehaviour {

    public float speed = 5;

    public Vector2 target;


    void Start() {
        target = new Vector2(-7, -4);
    }


    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void LixoAndar(Vector2 position) {
        target = position;
    }

   
}
