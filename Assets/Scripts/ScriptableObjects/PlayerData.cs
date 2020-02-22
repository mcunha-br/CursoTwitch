using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "BaseData")]
public class PlayerData : ScriptableObject {

    [Header("Settings Attack")]
    public AttackType type;
    public int aFire;
    public int aNomal;
    public int aIce;

    [Header("Setting Wek")]
    public int wFire;
    public int wNormal;
    public int wIce;
}


public enum AttackType {
    FIRE,
    ICE,
    NORMAL,
    WING,
}
