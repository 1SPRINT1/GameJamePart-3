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
            if (Input.GetKeyDown(KeyCode.Space))
            {
              //_rb.velocity = new Vector2(_rb.velocity.x, jumpForce);  
              _rb.AddForce(Vector2.up * jumpForce);
            }

        }

   // private void Flip()
   // {
   //     _sr.flipX = moveVector.x < 0;
   // }
    
}
