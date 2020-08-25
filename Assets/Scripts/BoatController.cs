using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController :  PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public int maxHealth=100;
    public int currentHealth;
    public HealthBars healthBars;
    public GameObject menuContainer;
    public GameObject SeaDown1;
    public GameObject SeaDown2;
    public GameObject SeaDown3;
    public GameObject Boat;
     // public GameObject cat;

      //camerashake
      public float camShakeAmt = 0.1f;
        public CameraShake cameraShake;
      

     // public GameObject gameobject;

    //private SpriteRenderer spriteRenderer;
   // public Animator animator;
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
       //animator.SetFloat("speed",Mathf.Abs(move.x));

        if (Input.GetButtonDown ("Jump")) {
          //  animator.SetBool("isJumping",true);
            velocity.y = jumpTakeOffSpeed;
           
         
        } else if (Input.GetButtonUp ("Jump")) 
        {//animator.SetBool("isJumping",false);
            if (velocity.y > 0) {
               // animator.SetBool("isJumping",false);
                velocity.y = velocity.y * 0.8f;
                 
            }
        }

       if (Input.GetKeyDown(KeyCode.UpArrow))
       { if (SeaDown2.active)
        { SeaDown1.SetActive(true);
          Boat.transform.position = new Vector3(Boat.transform.position.x, -1.361779f, transform.position.z);
          //cameraShake.Shake(0.5f,0.5f);
            SeaDown2.SetActive(false);
          
           }
           else 
           {SeaDown2.SetActive(true);
              Boat.transform.position = new Vector3(Boat.transform.position.x,-6.91225f, transform.position.z);
              //cameraShake.Shake(0.5f,0.5f);

           
           SeaDown1.SetActive(false);
           SeaDown3.SetActive(false);


           }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        { if (SeaDown2.active)
        {SeaDown3.SetActive(true);
          Boat.transform.position = new Vector3(Boat.transform.position.x, -11.74188f, transform.position.z);
          //cameraShake.Shake(0.5f,0.5f);
            SeaDown1.SetActive(false);
           
           SeaDown2.SetActive(false);}
           else 
           {SeaDown2.SetActive(true);
              Boat.transform.position = new Vector3(Boat.transform.position.x,-6.91225f, transform.position.z);
              //cameraShake.Shake(0.5f,0.5f);

           
           SeaDown1.SetActive(false);
           SeaDown3.SetActive(false);


           }
        }//animator.SetBool("isSliding",false);}
        
        //animator.SetBool ("grounded", grounded);
       // animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
    public void Damage(int damage)

    {  
        currentHealth -= damage;
        healthBars.setHeart(currentHealth);
        
         if (currentHealth <= 0 )
        {
            menuContainer.SetActive(true);}
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
         if(collider.tag == "enemyb")
     {
       // cameraShake.Shake(0.5f,0.5f);
         Damage(10);    
           
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