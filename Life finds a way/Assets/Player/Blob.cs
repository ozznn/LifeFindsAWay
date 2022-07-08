using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour{

    [SerializeField] float speed;
    [SerializeField] float DownSpeed;
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
        float verti = 0;
    }

    // Update is called once per frame
    void Update()
    {


         if (rb.velocity.magnitude > maxSpeed)
         {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
         }

        //blijf horizontaal georienteerd
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);

        RaycastHit2D hitInfo; //0.25 is hard coded omdat er verschillende groote players zijn alleen solid draait en daarom kan dit gewoon 0.25f
        hitInfo = Physics2D.Raycast(transform.position - new Vector3(0, 0.25f + 0.02f, 0), Vector2.down, 0.1f);
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

        Debug.DrawRay(transform.position - new Vector3(0, 0.25f + 0.02f, 0), Vector2.down*0.1f, Color.red);
    }

    void FixedUpdate()
    {
      float horiz = Input.GetAxis("Horizontal");
      rb.AddForce(Vector2.right * horiz * speed); //addfoce is voor acceleratie

      float verti = Input.GetAxis("Vertical");
      if(verti == -1){
        rb.AddForce(Vector2.up * verti * DownSpeed); //voor downforce
      }
    }
}
