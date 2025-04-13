using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCollision : MonoBehaviour
{
    public GameObject myText;
    void OnTriggerEnter2D(Collider2D other)
    {
        myText.SetActive(true);
    }
   
   void OnTriggerExit2D(Collider2D other)
   {
        myText.SetActive(false);
   }
}
