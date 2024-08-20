using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 30.0f;
    private float maxVelocity = 4.0f;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded = true;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        playerWalk();
        playerJump();
    }
    public void playerWalk(){
        float forceX = 0f;
        float vel = Mathf.Abs(rb.velocity.x);
        Vector2 temp = rb.transform.localScale;
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            if(vel<maxVelocity)
            forceX = speed;
        temp.x = 1;
        anim.SetBool("Walk",true);
        }
        else if (h < 0)
        {
            if(vel<maxVelocity)
            forceX = -speed;
        temp.x = -1;
        anim.SetBool("Walk",true);
        }
        else{
        anim.SetBool("Walk",false);
        }
        rb.transform.localScale = temp;
        rb.AddForce(new Vector2(forceX, 0));
    }

    public void playerJump(){
        if(Input.GetKey(KeyCode.Space)){
            if(isGrounded){
                 isGrounded = false;
                 rb.AddForce(new Vector2(0, 400));
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
