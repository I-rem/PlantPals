using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCollision : MonoBehaviour
{
    public GameObject myText;
    public GameObject textbox;
    bool canInterract = false;

    void Update()
    {
        if (canInterract && Input.GetKeyDown(KeyCode.E))
        {
            if (!textbox.activeInHierarchy)
            {
                canInterract = false;
                myText.SetActive(false);
                textbox.SetActive(true);
            }
            else
            {
                myText.SetActive(true);
                textbox.SetActive(false);
            }
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        myText.SetActive(true);
        canInterract = true;
    }
   
   void OnTriggerExit2D(Collider2D other)
   {
        canInterract = false;
        myText.SetActive(false);
   }
}
