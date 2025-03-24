using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour
{
    [System.Serializable]
    public class PlantType
    {
        public string name;
        public Sprite[] growthStages;
        public Sprite evolvedSprite;
    }

    public PlantType[] plantTypes;  // Assign different plant types in Inspector
    private PlantType selectedPlant;
    
    private SpriteRenderer spriteRenderer;
    private int growthStage = 0;
    private bool isWatered = false;
    private bool isEvolved = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Randomly select a plant type (or set it based on seed)
        selectedPlant = plantTypes[Random.Range(0, plantTypes.Length)];

        // Set initial sprite
        spriteRenderer.sprite = selectedPlant.growthStages[0];

        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        while (growthStage < selectedPlant.growthStages.Length - 1)
        {
            yield return new WaitForSeconds(isWatered ? 3f : 6f);
            growthStage++;
            spriteRenderer.sprite = selectedPlant.growthStages[growthStage];
        }
    }

    public void GrowFaster()
    {
        isWatered = true;
    }

    public void Evolve()
    {
        if (!isEvolved)
        {
            isEvolved = true;
            spriteRenderer.sprite = selectedPlant.evolvedSprite;
        }
    }
}
