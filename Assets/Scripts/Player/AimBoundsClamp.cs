using UnityEngine;

public class AimBoundsClamp : MonoBehaviour
{
    public SphereCollider boundsCollider;



    private void LateUpdate()
    {
        Vector3 currentPosition = transform.position;
        Vector3 clampedPosition = currentPosition;

        //get the bounds of the container collider
        Bounds bounds = boundsCollider.bounds;

        //clamp the x and z position
        clampedPosition.x = Mathf.Clamp(currentPosition.x, bounds.min.x, bounds.max.x);
        clampedPosition.z = Mathf.Clamp(currentPosition.z, bounds.min.z, bounds.max.z);

        transform.position = clampedPosition;
    }
}
