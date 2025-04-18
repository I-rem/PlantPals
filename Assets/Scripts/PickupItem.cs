using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public bool canPickup = false;
    private GameObject player;
    private Inventory inventory;
     public bool picked_up = false;

     public GameObject myText;
    void Start()
    {
        inventory = Inventory.instance;
    }

    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E)) 
        {
            myText.SetActive(false);
            inventory.AddItem(gameObject, inventory.GetComponent<Inventory>().currentItem);
           // gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5; 
           // Destroy(gameObject);  
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !picked_up)
        {
            canPickup = true;
            player = other.gameObject;
            myText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickup = false;
            if (picked_up)
                player = null;
            myText.SetActive(false);
         }
    }
}
