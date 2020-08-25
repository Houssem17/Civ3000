using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour

{

   public AudioClip audioClip2;
    AudioSource audio;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Player1"))
        {
            Inventory.instance.addGold(1);
            AudioSource.PlayClipAtPoint(audioClip2, transform.position);


            gameObject.SetActive(false);
           
        }
    }
}
