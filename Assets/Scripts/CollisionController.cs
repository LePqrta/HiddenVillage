using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="interactable"){
            Debug.Log("Interaction started");
        }

    }
    private void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.tag=="interactable"){
            Debug.Log("Interacting");
        }

    }
    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag=="interactable"){
            Debug.Log("Interaction Ended");
        }

    }
}
