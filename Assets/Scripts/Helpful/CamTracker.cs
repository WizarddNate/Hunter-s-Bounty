using UnityEngine;
using Unity.Cinemachine;

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
