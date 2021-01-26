using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    public int sceneToLoad;
    public Button button;
    public Lever lever;
    Animator anim;
    AudioManager audioMan;
    void Start()
    {
        audioMan = FindObjectOfType<AudioManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(button != null)
        {
            anim.SetBool("Open", button.isButtonOn);
        }
        if(lever != null)
        {
            anim.SetBool("Open", lever.isLeverOn);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && Input.GetAxisRaw("Vertical") >= 0.7f && anim.GetBool("Open"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    public void PlaySlide()
    {
        audioMan.sfxMan.Play(7);
    }
}
