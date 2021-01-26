using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    
    public AudioSource[] music;
    public int startSong;
    // Start is called before the first frame update
    private void Start()
    {
        Play(startSong);
    }
    public void Play(int index)
    {
        foreach(AudioSource song in music)
        {
            song.Stop();
        }
        music[index].Play();
    }
}
