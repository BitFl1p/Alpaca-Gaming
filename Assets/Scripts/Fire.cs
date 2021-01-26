using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            other.gameObject.GetComponent<Box>().burning = true;
        }
    }
}
