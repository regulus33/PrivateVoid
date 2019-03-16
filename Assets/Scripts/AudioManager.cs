using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource[] coins;
    public AudioSource[] impacts;
    public AudioSource[] negative;
    public AudioSource[] pause;
    public AudioSource[] soundTrack;
    public AudioSource[] ui;
    public AudioSource[] weird;

    public static AudioManager instance;

    // Use this for initialization
    void Start () {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Playimpacts(int soundToPlay)
    {
        impacts[soundToPlay].Play();
    }

    public void PlayCoins(int soundToPlay)
    {
        coins[soundToPlay].Play();
    }

    public void PlayNegative(int soundToPlay)
    {
        negative[soundToPlay].Play();
    }

    public void PlayPause(int soundToPlay)
    {
        pause[soundToPlay].Play();
    }

    public void PlayUI(int soundToPlay)
    {
        ui[soundToPlay].Play();
    }

    public void PlayWeird(int soundToPlay)
    {
        weird[soundToPlay].Play();
    }
    public void PlaySoundTrack(int musicToPlay)
    {
        if (!soundTrack[musicToPlay].isPlaying)
        {
            StopMusic();

            if (musicToPlay < soundTrack.Length)
            {
                soundTrack[musicToPlay].Play();
            }
        }
    }

    public void StopMusic()
    {
        for(int i = 0; i < soundTrack.Length; i++)
        {
            soundTrack[i].Stop();
        }
    }
}

