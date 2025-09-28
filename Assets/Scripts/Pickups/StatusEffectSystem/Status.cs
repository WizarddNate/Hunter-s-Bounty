using UnityEngine;


[CreateAssetMenu(menuName = "Status Effect")]
public class SlowdownStatus : ScriptableObject
{
    public string Name;
    public float DOTAmount;
    public float TickSpeed;
    public float MovementPenalty;
    public float Lifetime;

    public GameObject EffectParticles;
}
