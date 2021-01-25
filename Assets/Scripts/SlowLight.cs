using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowLight : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ghost")
        {
            other.gameObject.GetComponent<GhostController2D>().moveSpeed = 2f;
            other.gameObject.GetComponent<GhostController2D>().jumpPow = 5f;
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
