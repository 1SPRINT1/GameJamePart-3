using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public float speed = 0.1f;
    public Rigidbody2D physic;

    private bool isGrounded;
    private float groundRadius = 0.3f;

    public Transform groudCheck;
    public LayerMask groundMask;

    private void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groudCheck.position, groundRadius, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            physic.AddForce(new Vector2(0, 600));
        }

        if(Input.GetAxis("Horizontal") < 0)
        { 
            GetComponent<SpriteRenderer>().flipX = false; 
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

}
