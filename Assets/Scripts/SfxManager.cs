using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource[] sfx;
    // Start is called before the first frame update
    public void Play(int index)
    {
        sfx[index].Play();
    }
    public void Stop(int index)
    {
        sfx[index].Stop();
    }
    // Update is called once per frame

}
