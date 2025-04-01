using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip clickSound;
    public AudioClip bgm;

    AudioSource audioSource;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        
        if(audioSource == null )
        {
            audioSource=gameObject.AddComponent<AudioSource>();
        }

        if(bgm!=null)
        {
            PlayBGM();
        }
    }

    private void Update()
    {
        MouseClickSound();
    }

    void MouseClickSound()
    {
       if(Input.GetMouseButtonDown(0)) 
       {
           audioSource.PlayOneShot(clickSound);
        } 
    }

    void PlayBGM()
    {
        if (bgm!=null)
        {
            audioSource.clip = bgm;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
 }
