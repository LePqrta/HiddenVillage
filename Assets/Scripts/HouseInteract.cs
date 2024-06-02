using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class HouseInteract : MonoBehaviour
{
    private void Awake(){
        marketCanvas.SetActive(false);
    }
    public GameObject marketCanvas; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            Debug.Log("Entered house trigger");
            ShowInteractButton();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            Debug.Log("Exited house trigger");
            HideInteractButton();
        }
    }

    private void ShowInteractButton()
    {
        
        marketCanvas.SetActive(true);
    }

    private void HideInteractButton()
    {
        
        marketCanvas.SetActive(false);
    }
}