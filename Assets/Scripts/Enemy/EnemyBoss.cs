using UnityEngine;
using System.Collections;

public class EnemyBoss : Enemy {

    public string enemyName;

    private UIGamePlayer uIGamePlayer;

    protected new void Start() {
        base.Start();

        uIGamePlayer = FindObjectOfType<UIGamePlayer>();

        uIGamePlayer.SetConfigEnemy(health, enemyName, true);
    }


    protected override void OnDamage() {
        uIGamePlayer.healthEnemy.value = health;
    }


    protected override void OnDeath() {        
        GetComponentInParent<DragonController>().StopAllCoroutines();
        uIGamePlayer.SetConfigEnemy(health, enemyName, false);
        gameObject.SetActive(false);
    }
}
