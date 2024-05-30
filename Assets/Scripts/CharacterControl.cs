using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel.Design.Serialization;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

public class CharacterControl : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 targetPosition;
    private Vector3 targetCameraPosition;
    private float lerpDuration = 0.5f; // Adjust this value to control the speed of the movement
    private float cameraLerpDuration = 1f; // Adjust this value to control the speed of the camera movement
    private float zoomSpeed = 2f; // Adjust this value to control the zoom speed
    private float minZoomDistance = 1f; // Minimum distance between touch points to start zooming
    private float maxZoomDistance = 20f; // Maximum distance between touch points for zooming
    public GameObject interactIcon;
    public GameObject envanterButton;

    private Camera mainCamera;
    private float initialCameraSize;
    private float targetCameraSize;
    private float cameraZoomSmoothTime = 0.2f; // Adjust this value to control the smoothness of the zoom
    private bool isZooming = false; // Flag to indicate if the user is zooming
    public GameObject interactableCanvas;
    void Start()
    {
        //interactIcon.SetActive(false);
        mainCamera = Camera.main;
        initialCameraSize = mainCamera.orthographicSize;
        targetCameraSize = initialCameraSize;
        interactableCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f;
                targetPosition = touchPosition;
                targetCameraPosition = new Vector3(touchPosition.x, touchPosition.y, Camera.main.transform.position.z);
                isZooming = false; // Reset the zooming flag
                CheckInteraction();
            }
        }

        // Only move the character and camera if the user is not zooming
        if (!isZooming)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / lerpDuration);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetCameraPosition, Time.deltaTime / cameraLerpDuration);
        }

        // Smooth camera zoom
        mainCamera.orthographicSize = Mathf.SmoothDamp(mainCamera.orthographicSize, targetCameraSize, ref cameraZoomSmoothTime, cameraZoomSmoothTime);
    }

    public void ZoomIn()
    {
        isZooming = true; // Set the zooming flag
        targetCameraSize = Mathf.Max(minZoomDistance, targetCameraSize - zoomSpeed);
    }

    public void ZoomOut()
    {
        isZooming = true; // Set the zooming flag
        targetCameraSize = Mathf.Min(maxZoomDistance, targetCameraSize + zoomSpeed);
    }

    public void StartInteraction()
    {
        if(tag=="interactable"){
            interactableCanvas.SetActive(true);
        }
    }

    public void StopInteraction()
    {
        interactableCanvas.SetActive(false);
    }

    private void CheckInteraction()
    {
        // Implement the logic to check for interactable objects
        // and perform the appropriate actions
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        if (hit.collider != null)
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                // Interact with the object
                interactable.Interact(gameObject);
                StartInteraction();
            }
            else
            {
                StopInteraction();
            }
        }
        else
        {
            StopInteraction();
        }
    }
}