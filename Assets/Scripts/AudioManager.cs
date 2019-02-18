﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sfx;
    public AudioSource[] bgm;

    public static AudioManager instance; 
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            PlaySFX(0);
            StopMusic();
            PlayMusic(0);
        }

         if(Input.GetKeyDown(KeyCode.H))
        {
            PlaySFX(0);
            StopMusic();
        }
    }
    
    public void PlaySFX(int soundToPlay)
    {
        if(soundToPlay < sfx.Length)
        {
            sfx[soundToPlay].Play();
        }
    }

     public void PlayMusic(int musicToPlay)
    {
        //if this camera instances track is currently already playing from another scene, just keep playing it.
        if(!bgm[musicToPlay].isPlaying)
        {
            StopMusic();
            if(musicToPlay < bgm.Length)
            {
                bgm[musicToPlay].Play();
            }
        }
       
    }

    public void StopMusic()
    {
        for(int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }
}
