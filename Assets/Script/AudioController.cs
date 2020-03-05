using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour {

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        SceneManager.activeSceneChanged += onSceneChanged;
        
    }

    private void onSceneChanged(Scene previousScene, Scene nextScene) {
        try {
            AudioSource foundAudioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
            if (foundAudioSource != null) {
                this.audioSource.mute = true;
            }
            Debug.Log(foundAudioSource);
        } catch (NullReferenceException) {
            if (this.audioSource.mute) {
                this.audioSource.Play();
                this.audioSource.mute = false;
            }
        }
    }
}
