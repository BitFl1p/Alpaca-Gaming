using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class DeathLight : MonoBehaviour
{
    AudioManager audioMan;
    public float delay = 5;
    void Start()
    {
        audioMan = FindObjectOfType<AudioManager>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ghost")
        {
            audioMan.sfxMan.Play(6);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ghost")
        {
            
            other.gameObject.GetComponent<GhostController2D>().moveSpeed -= 0.02f;
            other.gameObject.GetComponent<GhostController2D>().jumpPow -= 0.1f;
            other.gameObject.GetComponent<GhostController2D>().cam.m_Lens.OrthographicSize -= 0.01f;
            if (other.gameObject.GetComponent<GhostController2D>().moveSpeed <= 0f)
            {
                other.gameObject.GetComponent<GhostController2D>().moveSpeed = 0f;
            }
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
            audioMan.sfxMan.Stop(6);
            other.gameObject.GetComponent<GhostController2D>().moveSpeed = 6f;
            other.gameObject.GetComponent<GhostController2D>().jumpPow = 8f;
            other.gameObject.GetComponent<GhostController2D>().cam.m_Lens.OrthographicSize = 6;
        }
    }
}
