using UnityEngine;

public class Seed : MonoBehaviour
{
    
    public GameObject plantPrefab; // Assign different plant prefabs per seed type in Inspector

    public void PlantSeed(Pot pot)
    {
        Debug.Log("Plant seed called");
       // if (pot.IsEmpty())
       // {
            //GameObject plant = Instantiate(plantPrefab, pot.transform.position, Quaternion.identity);
            GameObject plant = Instantiate(plantPrefab, pot.digPlace.transform.position, Quaternion.identity);
            pot.SetPlant(plant);
            Inventory.instance.DropItem(gameObject);
            Destroy(gameObject); // Remove seed after planting
      //  }
    }
}
