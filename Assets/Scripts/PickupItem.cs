using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public bool canPickup = false;
    private GameObject player;
    private Inventory inventory;
     public bool picked_up = false;
    void Start()
    {
        inventory = Inventory.instance;
    }

    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E)) 
        {
            inventory.AddItem(gameObject, inventory.GetComponent<Inventory>().currentItem);
           // Destroy(gameObject);  
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !picked_up)
        {
            canPickup = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && picked_up)
        {
            canPickup = false;
            player = null;
        }
    }
}
