using UnityEngine;
using System.Collections;
using TMPro;

public class Teste : MonoBehaviour {

    public int x, y;
    public GameObject prefab;
    public LixoMovement lixo;

    private float timer;
    private Vector2[,] teste;
    private int _x, _y;


    private void Start() {

        teste = new Vector2[x, y];

        for (int i = 0; i < x; i++) {
            for (int j = 0; j < y; j++) {
                teste[i, j] = new Vector2(i,j);
            }
        }        
    }


    private void Update() {
        timer += Time.deltaTime;

        if (timer >= 0.1f)
            timer = 0;
        else
            return;
        

        if(Input.GetKey(KeyCode.RightArrow)) {
            _x += 1;
        } else if(Input.GetKey(KeyCode.LeftArrow)) {
            _x -= 1;
        } else if(Input.GetKey(KeyCode.UpArrow)) {
            _y += 1;
        } else if(Input.GetKey(KeyCode.DownArrow)) {
            _y -= 1;
        }

        _x = Mathf.Clamp(_x, 0, x - 1);
        _y = Mathf.Clamp(_y, 0, y - 1);
       
        lixo.LixoAndar(teste[_x,_y]);
    }
}
