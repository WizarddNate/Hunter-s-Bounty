using UnityEngine;

public class FindCam : MonoBehaviour
{
    public Canvas worldSpaceCanvas; //assign canvas to world space
    public Camera eventCam; //assign event cam

    private void Awake()
    {
        GameObject _taggedCam = GameObject.FindGameObjectWithTag("MainCamera");
        eventCam = _taggedCam.GetComponent<Camera>();

        if (worldSpaceCanvas != null && eventCam != null)
        {
            // Make the Canvas Render Mode set to World Space
            if (worldSpaceCanvas.renderMode != RenderMode.WorldSpace)
            {
                worldSpaceCanvas.renderMode = RenderMode.WorldSpace;
            }

            // Assign the camera to the worldCamera property
            worldSpaceCanvas.worldCamera = eventCam;
        }
    }
}
