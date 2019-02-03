using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : Singleton<SoundManagement>
{
    public AudioClip Title;
    public AudioClip EventNumber12;
    public AudioClip KeyBoard;

    AudioSource myAudio;
    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>();
    }

    public void TitleSound()
    {
        myAudio.PlayOneShot(Title);
    }

    public void EventNumber13Sound()
    {
        myAudio.PlayOneShot(EventNumber12);
    }

    public void KeyboardSound()
    {
        myAudio.PlayOneShot(KeyBoard);
    }
}
