using UnityEngine;
using System.Collections;

public class chato : MonoBehaviour {

    public float speed;

    public Transform target;

    private bool canMove;

    void Start() {
        
    }


    void Update() {

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }


    public void Follow(Vector2 target, bool canMove) {
        this.target.position = target;
        this.canMove = canMove;
    }
}
