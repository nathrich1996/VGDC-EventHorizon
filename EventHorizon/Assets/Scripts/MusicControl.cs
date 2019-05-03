using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour
{

    public AudioClip overdrive;
    public AudioClip runTheme;

    public AudioClip buttonClick;
    public AudioClip lowFuel;
    public AudioClip collectFuel;
    public AudioClip shieldBreak;

    public AudioMixerSnapshot inOverdrive;
    public AudioMixerSnapshot running;
    public AudioMixerSnapshot dead;

    public AudioSource source;

    private float transitionIn;
    private float transitionOut;
    private float quarterNote;

    void Start()
    {
        quarterNote = 60 / 128;
        transitionIn = quarterNote * 32;
        transitionOut = quarterNote * 8;
        
    }

    public void OverdriveStart()
    {
        //if (overdriveInit == false)
        //{
        //    overdriveInit = true;
        //    source.clip = overdrive;
        //    source.Play();
        //}
        //else
        //{
        inOverdrive.TransitionTo(transitionIn);
        //}
    }
    public void RunStart()
    //public void RunStart(bool init)
    {
        //if (init == false)
        //{
        //    source.clip = runTheme;
        //    source.Play();
        //}
        //else
        //{
        running.TransitionTo(transitionOut);
        //}
    }

    public void DeathAudio()
    {
        dead.TransitionTo(0f);
    }


    public void CollectFuel()
    {
        source.clip = collectFuel;
        source.Play();
    }

    public void ShieldBreak()
    {
        source.PlayOneShot(shieldBreak, 1f);
    }

    public void ButtonClick()
    {
        source.PlayOneShot(buttonClick, 1f);
    }

}
