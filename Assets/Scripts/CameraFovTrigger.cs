using UnityEngine;
using System.Collections.Generic;

public class CameraFOVTrigger : MonoBehaviour
{
    public Camera mainCamera;
    public float normalFOV = 30f;
    public float observatoryFOV = 50f;
    public float fovChangeSpeed = 3f;

    private float targetFOV;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        targetFOV = normalFOV;
        mainCamera.fieldOfView = normalFOV;
    }

    void Update()
    {
        // Smooth FOV transition
        mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, targetFOV, Time.deltaTime * fovChangeSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered: " + other.name);
        if (other.CompareTag("Seagull"))
        {
            targetFOV = observatoryFOV;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Seagull"))
        {
            targetFOV = normalFOV;
        }
    }
}
