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
        if(tag=="interactable"){
            characterControl.interactableCanvas.SetActive(true);
        }

    
        // Example: Display a message
        ShowInteractMessage();
    }


    private void ShowInteractMessage()
    {
        // Display the interact text, for example using a UI element
        characterControl.OpenInteractableIcon();
    }

    private void HideInteractMessage()
    {
        characterControl.CloseInteractableIcon();
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a sphere to visualize the interact range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}