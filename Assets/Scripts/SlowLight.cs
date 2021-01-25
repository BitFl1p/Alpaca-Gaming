using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowLight : MonoBehaviour
{
    public bool speed = false;
    public float moveSpeed = 5f;

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
        if (!speed)
        {
            speed = true;
            Debug.Log("Hello");
            moveSpeed = 2f;
        }
    }
}
