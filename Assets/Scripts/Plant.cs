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

    public float waterLevel = 100.5f;  
    public float waterDecayRate = 0.1f;
    public float overwaterLimit = 800.0f;
    public float underwaterLimit = 0.1f;
    public Sprite deathSprite;

    private bool isDead = false;
    private Transform waterBarFill;

   
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        waterBarFill = transform.Find("Canvas/WaterBarBG/WaterBarFill").transform;
        // Set initial sprite
        if (evolutionStages.Length > 0)
        {
            spriteRenderer.sprite = evolutionStages[0].sprite;
        }

        StartCoroutine(Grow());
    }

    void Update()
    {
        if (isDead) return;

        waterLevel -= waterDecayRate * Time.deltaTime;
        UpdateWaterBar();

        if (waterLevel > overwaterLimit || waterLevel < underwaterLimit)
        {
            Die();
        }
    }

    public void UpdateWaterBar()
    {
       // waterLevel = Mathf.Clamp01(waterLevel);
        waterBarFill.localScale = new Vector3(waterLevel, 43.2f, 1f);
        
    }

    void Die()
    {
        isDead = true;
        StopAllCoroutines();
        spriteRenderer.color = Color.grey;

        if (deathSprite != null)
        {
            spriteRenderer.sprite = deathSprite;
        }
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
        //isWatered = true;
        if (isDead)
            return ;
        if (currentStage < evolutionStages.Length - 1)
             Evolve();
    }

    public void Evolve()
    {
        if (!isDead && currentStage < evolutionStages.Length - 1)
        {
            currentStage++;
            spriteRenderer.sprite = evolutionStages[currentStage].sprite;
        }
    }
}
