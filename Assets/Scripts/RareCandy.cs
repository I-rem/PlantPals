using UnityEngine;

public class RareCandy : MonoBehaviour
{
    public Pot pot;

    void OnMouseDown()
    {
        if (pot != null && pot.plantedSeed != null)
        {
           // pot.EvolveSeed(); 
          //  Destroy(gameObject);  
        }
    }
}
