using UnityEngine;

public class Pot : MonoBehaviour, IInteractable
{
    private bool hasSeed = false;
    private bool isWatered = false;
    public GameObject plantedSeed;
    public GameObject plantPrefab; // Assign plant prefab in Inspector

    public void Interact()
    {
        if (!hasSeed && Inventory.instance.currentItem != null)
        {
            if (Inventory.instance.currentItem.CompareTag("Interactable")) // Seeds are tagged as Interactable
            {
                PlantSeed(Inventory.instance.currentItem);
            }
        }
        else if (hasSeed && !isWatered && Inventory.instance.currentItem != null)
        {
            if (Inventory.instance.currentItem.CompareTag("Interactable")) // Watering can is also Interactable
            {
                WaterPlant();
            }
        }
    }

    public void PlantSeed(GameObject seed)
    {
        hasSeed = true;
        plantedSeed = Instantiate(plantPrefab, transform.position, Quaternion.identity);
        Inventory.instance.DropItem(seed); // Automatically drop the seed after planting
        Destroy(seed);
    }

    private void WaterPlant()
    {
        if (hasSeed && plantedSeed != null)
        {
            isWatered = true;
            plantedSeed.GetComponent<Plant>().GrowFaster();
        }
    }
}
