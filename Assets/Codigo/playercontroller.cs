using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
     private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb2d;
    private float speed = 3;
    private bool muere = false;
   
    private int puntos=0;
    // Start is called before the first frame update
    void Start()
    {
        sr= GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.gravityScale = 25;
        if(puntos==10){
            sr.flipX = true;
             
          
        }
         Correr();
         
        if(muere==false){
          if(Input.GetKey(KeyCode.Space))
            {            
            saltarF();
            
            }
            if(Input.GetKey(KeyCode.X))
            {
            Deslizar();
             rb2d.velocity = new Vector2(speed,rb2d.velocity.x);
            
            }
         }
         else{
            morir();
           
         }
    }
    void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.layer == 12){
           
         Destroy(other.gameObject);
           aumenta();
            speed = 1.5f;
           
        }
    }
    void OnTriggerEnter2D ( Collider2D other)//para morir
    {
       
        if(other.gameObject.layer == 10){
             Destroy(this.gameObject);
            
             muere = true; 
          
        }
         if(other.gameObject.layer == 11){
         Destroy(other.gameObject);
         
            speed = 1.5f;
           aumenta();
        }
    }
       public void saltarF(){
        var upSpeed = 80f;
        rb2d.velocity = Vector2.up * upSpeed;
        saltar();
    }
    public void Correr(){
        animator.SetInteger("estado", 0);        
    }
     public void Deslizar(){
        animator.SetInteger("estado", 1);        
    }
     public void saltar(){
        animator.SetInteger("estado", 2);        
    }
    public void morir(){
        animator.SetInteger("estado", 3);        
    }
    public void aumenta(){
         puntos +=1;
    }
}
