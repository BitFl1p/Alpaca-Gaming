using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathLight : MonoBehaviour
{

    public float delay = 5;
    void Start()
    {

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ghost")
        {
            other.gameObject.GetComponent<GhostController2D>().moveSpeed -= 0.05f;
            other.gameObject.GetComponent<GhostController2D>().jumpPow -= 0.05f;
            if (other.gameObject.GetComponent<GhostController2D>().jumpPow <= 0f && other.gameObject.GetComponent<GhostController2D>().moveSpeed <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ghost")
        {
            other.gameObject.GetComponent<GhostController2D>().moveSpeed = 6f;
            other.gameObject.GetComponent<GhostController2D>().jumpPow = 8f;
        }
    }
}
