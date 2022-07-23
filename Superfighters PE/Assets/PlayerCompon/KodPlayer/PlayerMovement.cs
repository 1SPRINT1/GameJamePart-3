using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;

    public float jumpForce = 10f;


    private Rigidbody2D _rb;

    public float StrafeS = 10f;

    public SpriteRenderer _sr;
    public Animator anim;
    
    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
    //    Flip();
        Reflect();
        Jump();
        CheckGround();
        CheckingLadder();
        LadderMechanics();
        LedderUpDown();
    }
    private void FixedUpdate() {
        moveVector.x = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(moveVector.x * speed , _rb.velocity.y);
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));    
           

    }
        public Vector2 moveVector;
        public bool faceRight;

         void Reflect()
        {
            if ((moveVector.x < 0 && !faceRight || moveVector.x > 0 && faceRight))
            {
                transform.localScale *= new Vector2(-1,1);
                faceRight = !faceRight;
            }
        }

        void Jump(){

            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                Physics2D.IgnoreLayerCollision(7, 8, true);
                Invoke("IgnoreLayerOff", 0.5f);
            }

            if (Input.GetKeyDown(KeyCode.Space) && onGrounded)//extraJumps >= 0)
            {
              //_rb.velocity = new Vector2(_rb.velocity.x, jumpForce); 
              _rb.velocity = new Vector2(_rb.velocity.x, 0); 
              _rb.AddForce(Vector2.up * jumpForce);
              
              //extraJumps--;
              
            }
           // if(extraJumps < 0){
             //   extraJumps++;
            //}
            //if(extraJumps < 0)
            //extraJumps++;

        }

   // private void Flip()
   // {
   //     _sr.flipX = moveVector.x < 0;
   // }

   public bool onGrounded;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground; 

   // public int extraJumps;

    void CheckGround(){
        onGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        anim.SetBool("onGrounded", onGrounded);
    }
   
    // private void OnDrawGizmos()
    //{
     //   Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(GroundCheck.position, checkRadius);
   // }
    void IgnoreLayerOff(){
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
    public float Check_Radius = 0.04f;
       private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(Check_Ladder.position, Check_Radius);
       }  
    public Transform Check_Ladder;
    public bool CheckedLadder;
    public LayerMask LadderMask;
    void CheckingLadder(){
        CheckedLadder = Physics2D.OverlapPoint(Check_Ladder.position, LadderMask);
    }
    public float LedderSpeed = 1.5f;
    void LadderMechanics(){
        if (CheckedLadder){
            _rb.bodyType = RigidbodyType2D.Kinematic;
            _rb.velocity = new Vector2(_rb.velocity.x, moveVector.y * LedderSpeed);
        }
         
        else {_rb.bodyType = RigidbodyType2D.Dynamic;}
    }
    void LedderUpDown(){
        moveVector.y = Input.GetAxis("Vertical");
    }
    
}
