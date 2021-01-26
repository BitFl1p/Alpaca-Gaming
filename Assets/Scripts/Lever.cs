using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{
    public bool isLeverOn = false;
    private Animator animLever;
    public AudioManager audioMan;
    // Start is called before the first frame update
    void Start()
    {
        animLever = GetComponent<Animator>();
        audioMan = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ghost")
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                switch (isLeverOn)
                {
                    case true:
                        isLeverOn = false;
                        break;
                    case false:
                        isLeverOn = true;
                        break;
                }

                audioMan.sfxMan.Play(4);
            }
            
        }
        
    }
    
    

    // Update is called once per frame
    void Update()
    {
        animLever.SetBool("Flipped", isLeverOn);
    }
}
