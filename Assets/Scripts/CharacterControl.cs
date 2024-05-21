using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel.Design.Serialization;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;

public class CharacterControl : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 targetPosition;
    private Vector3 targetCameraPosition;
    private float lerpDuration = 0.5f; // Adjust this value to control the speed of the movement
    private float cameraLerpDuration = 1f; // Adjust this value to control the speed of the camera movement
    public GameObject interactIcon;

    void Start()
    {
        //interactIcon.SetActive(false);
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
            }
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / lerpDuration);
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetCameraPosition, Time.deltaTime / cameraLerpDuration);
    }
    public void OpenInteractableIcon(){
        interactIcon.SetActive(true);
    }
    public void CloseInteractableIcon(){
         interactIcon.SetActive(false);       
    }
    private void CheckInteraction(){

    }
}