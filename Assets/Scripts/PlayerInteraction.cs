using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 2f; // Adjust based on player size
    public KeyCode interactKey = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactRange);

        foreach (Collider2D collider in colliders)
        {
            IInteractable interactable = collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
                break; // Only interact with one object at a time
            }
        }
    }
}
