using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float jumpHeight;
    public KeyCode jumpKey;
    public KeyCode L;
    public KeyCode R;

    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isGrounded;
public Transform groundCheck;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKey(L))
        {
           GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
           if(GetComponent<SpriteRenderer>()!= null)
           {    
                GetComponent<SpriteRenderer>().flipX = true;
           }
         
        }
        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if(GetComponent<SpriteRenderer>()!= null)
           {    
                GetComponent<SpriteRenderer>().flipX = false;
           }
        }
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }   
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
