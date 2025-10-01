using Unity.Cinemachine;
using UnityEngine;


/// <summary>
/// Failsafe to make sure that the camera angle STAYS isometric
/// </summary>
public class IsoCamAngle : MonoBehaviour
{
    public CinemachineCamera ccam;

    void Start()
    {
        ccam.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 45, transform.eulerAngles.z);
    }
}
