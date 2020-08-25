using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public int maxHealth=100;
    public int currentHealth;
    public HealthBars healthBars;
    public GameObject menuContainer;
      public GameObject cat;
      public AudioClip audioClip;
      public AudioClip audioClip1;
      public AudioClip audioClip2;
    AudioSource audio;
    public Joystick joystick;

      //camerashake
      public float camShakeAmt = 0.1f;
        public CameraShake cameraShake;
      

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
if (joystick.Horizontal >=0){
        move.x = joystick.Horizontal;
       animator.SetFloat("speed",Mathf.Abs(move.x));
       }

        if (Input.GetButtonDown ("Jump")) {
            animator.SetBool("isJumping",true);
            
            velocity.y = jumpTakeOffSpeed;
             AudioSource.PlayClipAtPoint(audioClip, transform.position);
            
           
         
        } else if (Input.GetButtonUp ("Jump")) 
        {animator.SetBool("isJumping",false);
            if (velocity.y > 0) {
               // animator.SetBool("isJumping",false);
                velocity.y = velocity.y * 0.8f;
               // AudioSource.PlayClipAtPoint(audioClip, transform.position);
                 
            }
        }

       if (Input.GetButtonDown ("Vertical"))
       {animator.SetBool ("isSliding",true);
        AudioSource.PlayClipAtPoint(audioClip2, transform.position);
        //move.x += 10f; 
         //move.x += 10f;
         //targetVelocity = move * maxSpeed;


       }
        else if (Input.GetButtonUp ("Vertical")) 
        {animator.SetBool("isSliding",false);}
        
        //animator.SetBool ("grounded", grounded);
       // animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
    public void Damage(int damage)

    {  
        currentHealth -= damage;
        healthBars.setHeart(currentHealth);
        AudioSource.PlayClipAtPoint(audioClip1, transform.position);
        
         if (currentHealth <= 0 )
        {
            menuContainer.SetActive(true);}
    }

    public void Hp(int hp)

    {  
        currentHealth += hp;
        healthBars.setHeart(currentHealth);
        
         
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
         if(collider.tag == "hp")
     {
       // cameraShake.Shake(0.5f,0.5f);
         Hp(20);    
           
     }
           
        
    }


     public Vector3 GetPosition()
    {
        return transform.position;
    }
}