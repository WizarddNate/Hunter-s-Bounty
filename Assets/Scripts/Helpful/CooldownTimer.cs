using UnityEngine;

/// <summary>
/// simple cooldown timer
/// </summary>
[System.Serializable]

public class CooldownTimer
{
    //amount of time it takes to cool down
    public float coolDownAmount;

    //the time that the cooldown is completed 
    private float m_coolDownCompleteTime;

    //is the cool down complete?
    public bool CoolDownComplete => Time.time > m_coolDownCompleteTime;

    public void StartCooldown()
    {
        m_coolDownCompleteTime = Time.time + coolDownAmount;
    }
}
