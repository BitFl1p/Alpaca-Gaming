using UnityEngine;
using UnityEngine.Events;

public class GhostController2D : MonoBehaviour
{
    public float jumpPow;
    //player must have a rigidbody2D and a box colider
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    float lastMoveX;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        
        //Physics2D.IgnoreCollision()
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        
        if (rb.velocity.x > 0f)
        {
            lastMoveX = 1;
        } else if (rb.velocity.x < 0f)
        {
            lastMoveX = -1;
        }
        Flip();
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

