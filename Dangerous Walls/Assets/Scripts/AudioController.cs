using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{ 
    public AudioMixer audioMixer;

    public void Sound() {
        AudioListener.pause = !AudioListener.pause;
    }
}