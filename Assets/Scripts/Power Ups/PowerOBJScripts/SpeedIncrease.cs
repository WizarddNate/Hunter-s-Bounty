using UnityEngine;

[CreateAssetMenu(fileName = "Powerups/SpeedIncrease")]
public class SpeedIncrease : PowerupSO
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

        target.GetComponent<MovementSM>().maxSpeed += value;
    }
}
