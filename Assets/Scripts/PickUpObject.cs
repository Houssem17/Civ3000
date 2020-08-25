using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    
    public AudioClip audioClip;
    AudioSource audio;
    //public bool Played=false;
    
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }
    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider)
    {  

        if (collider.CompareTag("Player1"))
        {
              
            Inventory.instance.addCoins(1);
            


             AudioSource.PlayClipAtPoint(audioClip, transform.position);
             Destroy(gameObject);
           
        }
        else {
           // audioSource.Stop();
        }
    }
}
