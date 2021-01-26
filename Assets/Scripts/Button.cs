using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    AudioManager audioMan;
    public bool isButtonOn = false;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioMan = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioMan.sfxMan.Play(5);
            isButtonOn = true;
            anim.SetBool("pressed", true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioMan.sfxMan.Play(5);
            isButtonOn = false;
            anim.SetBool("pressed", false);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
