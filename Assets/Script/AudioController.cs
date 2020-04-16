using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour {

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {
        SceneManager.activeSceneChanged += onSceneChanged;
    }

    // Update is called once per frame
    void Update() {
        
        
    }

    private void onSceneChanged(Scene previousScene, Scene nextScene) {
        try {
            AudioSource foundAudioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
            if (foundAudioSource != null) {
                audioSource.mute = true;
            }

        } catch (NullReferenceException) {
            
            if (audioSource.mute) {
                audioSource.Play();
                audioSource.mute = false;
            }
            
        } 
    }

    public void PauseAudio() {
        audioSource.Pause();
    }

    public void ResumeAudio() {
        audioSource.UnPause();
    }
}
