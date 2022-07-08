using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//f
public class Fly : MonoBehaviour{

    [SerializeField] float slow;
    [SerializeField] float speed;
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
        if (rb.velocity.magnitude > maxSpeed)
         {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
         }



        //blijf horizontaal georienteerd
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);

        //ook niet mooi dit volgende stuk:
        RaycastHit2D hitInfo;
        RaycastHit2D hitInfo2;
        RaycastHit2D hitInfo3;
        RaycastHit2D hitInfo4;

        hitInfo = Physics2D.Raycast(transform.position - new Vector3(0, sprite.bounds.extents.y + 0.02f, 0), Vector2.down, 0.1f);
        hitInfo2 = Physics2D.Raycast(transform.position + new Vector3(0, sprite.bounds.extents.y + 0.02f, 0), Vector2.up, 0.1f);
        hitInfo3 = Physics2D.Raycast(transform.position - new Vector3(sprite.bounds.extents.x + 0.02f, 0, 0), Vector2.left, 0.1f);
        hitInfo4 = Physics2D.Raycast(transform.position + new Vector3(sprite.bounds.extents.x + 0.02f, 0, 0), Vector2.right, 0.1f);

        if (hitInfo || hitInfo2 || hitInfo3 || hitInfo4)
        {
            isGrounded = true; //dit moet nog anders, return isGround???
        }
        else
        {
            isGrounded = false;
        }

        Debug.DrawRay(transform.position - new Vector3(0, sprite.bounds.extents.y + 0.02f, 0), Vector2.down*0.1f, Color.red);
        Debug.DrawRay(transform.position + new Vector3(0, sprite.bounds.extents.y + 0.02f, 0), Vector2.up*0.1f, Color.blue);
        Debug.DrawRay(transform.position - new Vector3(sprite.bounds.extents.x + 0.02f, 0, 0), Vector2.left*0.1f, Color.green);
        Debug.DrawRay(transform.position + new Vector3(sprite.bounds.extents.x + 0.02f, 0, 0), Vector2.right*0.1f, Color.yellow);
    }

    void FixedUpdate()
    {
      float horiz = Input.GetAxis("Horizontal");
      rb.AddForce(Vector2.right * horiz * speed); //addfoce is voor acceleratie

      float verti = Input.GetAxis("Vertical");
      rb.AddForce(Vector2.up * verti * speed); //addfoce is voor acceleratie

      //slow down
      rb.velocity *= slow;
    }
}
