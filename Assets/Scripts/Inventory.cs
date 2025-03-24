using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public GameObject currentItem = null;
    public Transform itemCarryPosition; 

    private GameObject lastDroppedItem;
   

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Update()
    {
        if (currentItem != null)
        {
            currentItem.transform.position = itemCarryPosition.position;  // Make the item follow the player
            currentItem.GetComponent<PickupItem>().picked_up = true;
            currentItem.GetComponent<PickupItem>().canPickup = false;
        }
    }

    public void AddItem(GameObject item, GameObject olditem)
    {
        if (currentItem != null)
        {
            DropItem(item);  // Drop the currently held item before picking up a new one
        }

        //currentItem = Instantiate(item, itemCarryPosition.position, Quaternion.identity);
        currentItem = item;
        currentItem.transform.SetParent(itemCarryPosition);
        currentItem.GetComponent<PickupItem>().picked_up = true;
        currentItem.GetComponent<PickupItem>().canPickup = false;
        if (olditem != null)
            olditem.GetComponent<PickupItem>().picked_up = false;
    }

    public void DropItem(GameObject item)
    {
        if (currentItem != null)
        {
            //currentItem.transform.SetParent(item.transform);
            Debug.Log(item);
            currentItem.transform.SetParent(null);
            
            currentItem = null;
            AddItem(item, currentItem);
            
           //item.GetComponent<PickupItem>().picked_up = true;
           // currentItem = item;
            //currentItem.transform.SetParent(itemCarryPosition);
            
        }
    }
}
