using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactText = "Interact";
    public float interactRange = 2f;

    

    private CharacterControl characterControl;

    private void Start()
    {
        characterControl = FindObjectOfType<CharacterControl>();
    }

    public void Interact(GameObject character)
    {
        // Implement the interaction logic here
        Debug.Log("Interacting with " + tag);
        if(tag=="Envanter"){
            characterControl.interactableCanvas.SetActive(true);
        }
        InteractionStart();
    }


    private void InteractionStart()
    {
        
        characterControl.StartInteraction();
    }

    private void StopInteraction()
    {
        characterControl.StopInteraction();
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a sphere to visualize the interact range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}