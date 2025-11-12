using UnityEngine;

[CreateAssetMenu(fileName = "Powerups/DamageIncrease")]
public class DamageIncrease : PowerupSO
{
    public int value;

    public override void Apply()
    {
       GameObject target = GameObject.FindWithTag("Weapon");

        if (target == null)
        {
            Debug.LogError("Player weapon not found");
            return;
        }

        target.GetComponent<MeleeWeapon>().meleeDamage += value;
    }
}
