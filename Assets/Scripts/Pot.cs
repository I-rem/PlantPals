using UnityEngine;

public class Pot : MonoBehaviour, IInteractable
{
    private bool hasSeed = false;
    private bool isWatered = false;
    public GameObject plantedSeed;
    
    public void Interact()
    {
        Debug.Log("Interact called");
        if (!hasSeed && Inventory.instance.currentItem != null)
        {
            Seed seed = Inventory.instance.currentItem.GetComponent<Seed>();
            if (seed != null)
            {
                PlantSeed(seed);
            }
        }
        else if (hasSeed && !isWatered && Inventory.instance.currentItem != null)
        {
            if (Inventory.instance.currentItem.CompareTag("WateringCan"))
            {
                WaterPlant();
            }
        }
    }

    public void PlantSeed(Seed seed)
    {
        hasSeed = true;
        seed.PlantSeed(this);
    }

    public void SetPlant(GameObject plant)
    {
        plantedSeed = plant;
    }

    public bool IsEmpty()
    {
        return !hasSeed;
    }

    private void WaterPlant()
    {
        if (plantedSeed != null)
        {
            isWatered = true;
            plantedSeed.GetComponent<Plant>().GrowFaster();
        }
    }
}
