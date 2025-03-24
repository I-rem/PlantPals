using UnityEngine;

public class WateringPot : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("You are holding a watering pot!");
    }
}
