using UnityEngine;

[CreateAssetMenu(fileName = "New Power-up", menuName = "Power-up")]
public class PowerupSO : ScriptableObject
{
    public Sprite image;

    public string text;

    public PowerupEffect effectType; //the effect

    public float effectValue; // the value of the effect

    public bool isUnique; //can the player get it once or multiple times

    public int unlockLevel; //only unlock the effect after a certain amount of rooms

    //apply effect to player
    //public void Apply(GameObject target);
}

public enum PowerupEffect
{
    DamageIncrease,
    HealthIncrease,
    SpeedIncrease,
    ReduceDashCooldown
}

