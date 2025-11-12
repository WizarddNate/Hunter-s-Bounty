using UnityEngine;

[CreateAssetMenu(fileName = "Powerups/HPIncrease")]
public class HealthIncrease : PowerupSO
{
    public int value;

    public override void Apply()
    {
        GameObject target = GameObject.FindWithTag("Player");

        if (target == null)
        {
            Debug.LogError("Player not found");
            return;
        }

        target.GetComponent<PlayerHealth>().health += value;
    }
}
