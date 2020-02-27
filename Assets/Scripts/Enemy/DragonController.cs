using UnityEngine;
using System.Collections;

public class DragonController : MonoBehaviour {

    public float speed;
    public Transform A, B, dragon;

    public Transform fire;

    private Vector3 target;
    private bool bossDeath;


    void Start() {

        target = A.position;

        dragon.position = target;

        StartCoroutine("Fireing");
    }


    void Update() {

        dragon.position = Vector2.MoveTowards(dragon.position, target, speed * Time.deltaTime);
        dragon.rotation = (target == A.position) ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);
        
        if(dragon.position == target) {
            target = (target == A.position) ? B.position : A.position;
        }
    }


    
    private IEnumerator Fireing() {
        var rand = Random.Range(8, 15);
        yield return new WaitForSeconds(rand);

        fire.gameObject.SetActive(true);
        var scale = fire.localScale;

        while(scale.x < 15) {
            scale.x += Time.deltaTime * 20;            
            fire.localScale = scale;
            yield return null;
        }


        yield return new WaitForSeconds(3);

        while(scale.x > 0.1f) {
            scale.x -= Time.deltaTime * 30;
            fire.localScale = scale;
            yield return null;
        }

        fire.gameObject.SetActive(false);


        StartCoroutine("Fireing");
    }
}
