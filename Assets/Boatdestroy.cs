using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boatdestroy : MonoBehaviour

{
public Animator animator;

     private void OnTriggerEnter2D(Collider2D collider)
    {
         if(collider.tag == "Player")
     {
          animator.SetBool("isDestroyed",true);
          
          //animator.SetBool("isDestroyed",false);
        
       // cameraShake.Shake(0.5f,0.5f);
         
           
     }}
     // Destroy(gameObject);}
}
