using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour
{
    public Sprite[] growthStages; // Assign plant sprites in Inspector
    private SpriteRenderer spriteRenderer;
    private int growthStage = 0;
    private bool isWatered = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        while (growthStage < growthStages.Length - 1)
        {
            yield return new WaitForSeconds(isWatered ? 3f : 6f); // Watered plants grow faster
            growthStage++;
            spriteRenderer.sprite = growthStages[growthStage];
        }
    }

    public void GrowFaster()
    {
        isWatered = true;
    }
}
