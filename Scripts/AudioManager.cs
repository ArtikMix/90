using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = 1f;
            s.source.pitch = 1f;
        }
    }

    public void PlayIt(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void StopIt(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void PlayIt(string name, bool lp, float vol)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.loop = lp;
        s.source.volume = vol;
        s.source.Play();
    }
}
