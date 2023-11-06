using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayMusic : MonoBehaviour
{
    public string soundToPlay;
    public string soundToStop;
    void Start()
    {
        Play(soundToPlay);
        Stop(soundToStop);
    }

    public void Play(string name)
    {
        AudioManager.instance.PlaySound(name);
    }

    public void Stop(string name)
    {
        AudioManager.instance.StopSound(name);
    }

}
