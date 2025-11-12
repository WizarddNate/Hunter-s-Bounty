using UnityEngine;


public class PowerupSO : ScriptableObject
{
    public Sprite image;

    public string text;

    public bool isUnique; //can the player get it once or multiple times

    public int unlockLevel; //only unlock the effect after a certain amount of rooms

    //apply effect to player
    public virtual void Apply() {}
}


/*
public enum PowerupEffect
{
    DamageIncrease,
    HealthIncrease,
    SpeedIncrease,
    ReduceDashCooldown
} */

