using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour {
    public AudioMixer mixer;
    public float defaultValue = -15f;

    public void SwitchAudio(string name) {
        mixer.GetFloat(name, out float value);
        if (value <= -79) {
            mixer.SetFloat(name, defaultValue);
        }
        else {
            mixer.SetFloat(name, -80);
        }
        
    }
    
}
