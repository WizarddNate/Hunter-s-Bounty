using UnityEngine;

[CreateAssetMenu(fileName = "Powerups/DashSpeedIncrease")]
public class DashSpeedIncrease : PowerupSO
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

        target.GetComponent<MovementSM>().dashSpeed += value;
    }
}
