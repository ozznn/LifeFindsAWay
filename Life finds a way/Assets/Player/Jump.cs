using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour{

    [SerializeField] float speed;
    [SerializeField] float JumpForce;
    [SerializeField] float maxSpeed = 40f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    //private Animator anim;

    public bool isGrounded;

// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();
        isGrounded = true;
        float horiz = 0;
    }

    // Update is called once per frame
    void Update()
    {
         //addfoce is voor acceleratie

         if (rb.velocity.magnitude > maxSpeed)
         {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
         }


        RaycastHit2D hitInfo; //hier pakt hij de lengte van de sprite over de y as en voegt daar 0.02f toe, dit is noodzakelijk om de rotatie bij te kunnen houden zodat hij altijd kan springen. ook op de lange kanten van het vierkant
        hitInfo = Physics2D.Raycast(transform.position - new Vector3(0, sprite.bounds.extents.y + 0.02f, 0), Vector2.down, 0.1f);
        if (hitInfo)
        {
            isGrounded = true; //dit moet nog anders, return isGround???
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * JumpForce);
        }

        Debug.DrawRay(transform.position - new Vector3(0, sprite.bounds.extents.y + 0.02f, 0), Vector2.down*0.1f, Color.red);
    }
    void FixedUpdate(){
      float horiz = Input.GetAxis("Horizontal");
      rb.AddForce(Vector2.right * horiz * speed);
    }

}
