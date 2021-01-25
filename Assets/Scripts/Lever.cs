using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{
    public bool isLeverOn = false;
    //private Animator animLever;
    // Start is called before the first frame update
    void Start()
    {
        //animLever = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (isLeverOn == false)
                {
                    isLeverOn = true;
                     //animLever.SetBool("LeverUnpressed", true);
                }
                if(isLeverOn == true)
                {
                    isLeverOn = false;
                }
                
            }
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
                //animLever.SetBool("pressed", false);
        }
    } 
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
