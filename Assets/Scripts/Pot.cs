using UnityEngine;
using System.Collections;

public class Pot : MonoBehaviour, IInteractable
{
    private bool hasSeed = false;
    private bool isWatered = false;
    public GameObject plantedSeed;
    
    public GameObject digPlace;
    
    public GameObject AudioManager;
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
            //isWatered = true;
            plantedSeed.GetComponent<Plant>().GrowFaster();
            StartCoroutine(RotateWateringCan(Inventory.instance.currentItem.transform));
            AudioManager.GetComponent<AudioManager>().OneShot("GlugGlug");
            
        }
    }

    IEnumerator RotateWateringCan(Transform wateringCan)
{
    float duration = 0.2f;
    float angle = -30f;

    Quaternion startRotation = wateringCan.rotation;
    Quaternion rotated = Quaternion.Euler(0, 0, angle);
    Quaternion endRotation = startRotation * rotated;

    float t = 0;
    while (t < 1f)
    {
        t += Time.deltaTime / duration;
        wateringCan.rotation = Quaternion.Slerp(startRotation, endRotation, t);
        yield return null;
    }

    // Return to original rotation
    t = 0;
    while (t < 1f)
    {
        t += Time.deltaTime / duration;
        wateringCan.rotation = Quaternion.Slerp(endRotation, startRotation, t);
        yield return null;
    }
}


}
