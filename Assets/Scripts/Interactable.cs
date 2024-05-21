using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D collidingObject){
        if(collidingObject.tag=="Player"){
            collidingObject.GetComponent<CharacterControl>().OpenInteractableIcon();
        }
    }
    private void OnTriggerExit2D(Collider2D collidingObject){
        if(collidingObject.tag=="Player"){
            collidingObject.GetComponent<CharacterControl>().CloseInteractableIcon();
        }
    }
    public void OnInteractionStart(GameObject character)
    {
        // Perform any necessary setup for the interaction


    }

    public void Interact(GameObject character)
    {

    }
}
