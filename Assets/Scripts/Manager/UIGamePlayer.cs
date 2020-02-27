using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class UIGamePlayer : MonoBehaviour {

    [Header("Settings Player")]
    public Slider health;


    [Header("Settings Enemy Boss")]
    public GameObject hudEnemy;
    public Slider healthEnemy;
    public TextMeshProUGUI tmpEnemyName;



    public void SetConfigEnemy(float health, string name, bool hud) {
        hudEnemy.SetActive(hud);
        healthEnemy.maxValue = health;
        healthEnemy.value = health;
        tmpEnemyName.text = name;
    }   
}
