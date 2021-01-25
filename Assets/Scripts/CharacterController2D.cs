using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    public float jumpPow;
    //player must have a rigidbody2D and a box colider
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    float lastMoveX;
    Animator anim;
    public GameObject fire;
    public bool ghostActive = false;
    public GameObject ghost;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ghostActive && Input.GetKeyDown(KeyCode.F))
        {
            anim.SetBool("Moving", false);
            GetComponent<Collider2D>().enabled = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = Vector2.zero;
            ghost.SetActive(false);
            ghostActive = false;
            return;
        }
        else if (ghostActive)
        {
            return;
        }
        else if (!ghostActive && Input.GetKeyDown(KeyCode.F) && IsGrounded())
        {
            ghost.GetComponent<GhostController2D>().lastMoveX = lastMoveX;
            ghost.transform.position = transform.position;
            
            anim.SetBool("Moving", false);
            GetComponent<Collider2D>().enabled = false;
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static;
            ghost.SetActive(true);
            ghostActive = true;
            return;
        }
        ghost.GetComponent<GhostController2D>().lastMoveX = lastMoveX;
        ghost.transform.position = transform.position;
        GetComponent<Collider2D>().enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        if (Input.GetKey(KeyCode.E) && IsGrounded())
        {
            anim.SetBool("Fire", true);
            rb.velocity = Vector2.zero;
            return;

        }
        else
        {
            anim.SetBool("Fire", false);
        }
        Jump();

        anim.SetBool("Jumping", !IsGrounded());
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        if(rb.velocity.x != 0)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
        if (rb.velocity.x > 0f)
        {
            
            lastMoveX = 1;
        } else if (rb.velocity.x < 0f)
        {
            lastMoveX = -1;
        }
        Flip();

        // Fire mechanics
        
    }
    public void FireTrue()
    {
        fire.SetActive(true);
    }
    public void FireFalse()
    {
        fire.SetActive(false);
    }
    public LayerMask groundLayer;

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 2.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
    
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPow);
        }
    }
    void Flip()
    {
        switch (lastMoveX)
        {
            case 1f:
                transform.localScale = new Vector3(-1,1,1);
                break;
            case -1f:
                transform.localScale = new Vector3(1, 1, 1);
                break;
        }
    }
   
}

