using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerScript : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public string ControllerName;

    public void SetVolume(float Value)
    {
        AudioMixer.SetFloat(ControllerName, Mathf.Log10(Value) * 20);
    }
}
