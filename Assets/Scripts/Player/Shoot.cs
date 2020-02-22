using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float speed;

    private void Start() {
        Destroy(gameObject, 2);
    }


    private void Update() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
    }
}
