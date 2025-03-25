using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour
{
    [System.Serializable]
    public class EvolutionStage
    {
        public string name;
        public Sprite sprite;
    }

    public EvolutionStage[] evolutionStages;
    private int currentStage = 0;
    private bool isWatered = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set initial sprite
        if (evolutionStages.Length > 0)
        {
            spriteRenderer.sprite = evolutionStages[0].sprite;
        }

        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        while (currentStage < evolutionStages.Length - 1)
        {
            yield return new WaitForSeconds(isWatered ? 3f : 12f);
            Evolve();
        }
    }

    public void GrowFaster()
    {
        isWatered = true;
    }

    public void Evolve()
    {
        if (currentStage < evolutionStages.Length - 1)
        {
            currentStage++;
            spriteRenderer.sprite = evolutionStages[currentStage].sprite;
        }
    }
}
