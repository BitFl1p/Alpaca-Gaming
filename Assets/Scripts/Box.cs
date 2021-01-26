using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject fire;
    Animator anim;
    public bool burning = false;
    private void Start()
    {
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        anim.SetBool("Burn", burning);
    }
    public void Burn()
    {
        fire.SetActive(true);
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
