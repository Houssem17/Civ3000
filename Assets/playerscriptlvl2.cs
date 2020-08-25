using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscriptlvl2 : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public int maxHealth=100;
    public int currentHealth;
    public HealthBars healthBars;
    public GameObject menuContainer;
    public AudioClip audioClip;
    AudioSource audio;

     

      
      

     // public GameObject gameobject;

    //private SpriteRenderer spriteRenderer;
    public Animator animator;
    void Start()
    {
        
        currentHealth = maxHealth;
        healthBars.setMaxHeart(maxHealth);
    }

    // Use this for initialization
    void Awake () 
    {
      // spriteRenderer = GetComponent<SpriteRenderer> ();    
        //animator = GetComponent<Animator> ();
    }

   
    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");
      // animator.SetFloat("speed",Mathf.Abs(move.x));

        if (Input.GetButtonDown ("Jump")) {
            //animator.SetBool("isJumping",true);
            //velocity.y = jumpTakeOffSpeed;
           
         
        } else if (Input.GetButtonUp ("Jump")) 
        {//animator.SetBool("isJumping",false);
            if (velocity.y > 0) {
               // animator.SetBool("isJumping",false);
                velocity.y = velocity.y * 0.8f;
                 
            }
        }

       if (Input.GetButtonDown ("Vertical"))
       {//animator.SetBool ("isSliding",true);
        //move.x += 10f; 
         //move.x += 10f;
         //targetVelocity = move * maxSpeed;


       }
        else if (Input.GetButtonUp ("Vertical")) 
        {}//animator.SetBool("isSliding",false);}
        
        //animator.SetBool ("grounded", grounded);
       // animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
    public void Damage(int damage)

    {  
        currentHealth -= damage;
        healthBars.setHeart(currentHealth);
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        
         if (currentHealth <= 0 )
        {
            menuContainer.SetActive(true);}
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
         if(collider.tag == "enemy")
     {
       // cameraShake.Shake(0.5f,0.5f);
         Damage(20);    
           
     }
       if (collider.CompareTag("Cat"))
        {
           // cameraShake.Shake(0.10f,0.5f);
            Damage(100);
        
            
            
        }
           
        
    }


     public Vector3 GetPosition()
    {
        return transform.position;
    }
}