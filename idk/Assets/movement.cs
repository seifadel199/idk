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
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
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
        anim.SetFloat("speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetFloat("hight", GetComponent<Rigidbody2D>().velocity.y);
        anim.SetBool("Grounded", isGrounded);

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
