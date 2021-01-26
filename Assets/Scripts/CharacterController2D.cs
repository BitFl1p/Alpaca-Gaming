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
    public AudioManager audioMan;
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
            GetComponent<Collider2D>().isTrigger = false;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 4;
            ghost.SetActive(false);
            ghostActive = false;
            return;
        }
        else if (ghostActive)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        else if (!ghostActive && Input.GetKeyDown(KeyCode.F) && IsGrounded())
        {
            ghost.GetComponent<GhostController2D>().lastMoveX = lastMoveX;
            ghost.transform.position = transform.position;
            audioMan.sfxMan.Play(3);
            anim.SetBool("Moving", false);
            GetComponent<Collider2D>().isTrigger = true;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            ghost.SetActive(true);
            ghostActive = true;
            return;
        }
        ghost.GetComponent<GhostController2D>().lastMoveX = lastMoveX;
        ghost.transform.position = transform.position;
        GetComponent<Collider2D>().isTrigger = false;
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
        rb.gravityScale = 4;
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
    public LayerMask spookroundLayer;

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
        hit = Physics2D.Raycast(position, direction, distance, spookroundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
    public void PlayFireWoosh() { audioMan.sfxMan.Play(0); }
    public void PlayFire() { audioMan.sfxMan.Play(1); }
    public void StopFire() { audioMan.sfxMan.Stop(1); }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            audioMan.sfxMan.Play(2);
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

