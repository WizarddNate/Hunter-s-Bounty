using UnityEngine;
using Unity.Cinemachine;

/// <summary>
/// Make sure that the camera locks on to the player upon starting the level
/// </summary>
public class CamTracker : MonoBehaviour
{
    public CinemachineCamera ccam;

    private Transform player;
    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;

        ccam.Target.TrackingTarget = player;
    }
}
