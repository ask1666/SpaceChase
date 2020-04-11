using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Advertisement : MonoBehaviour {

    private InterstitialAd interstitial;
    public GameObject canvas;
    private bool adDisplayed;
    public AudioController AC;

    private void Awake() {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        RequestInterstitial();
    }

    // Start is called before the first frame update
    void Start() {

        SceneManager.sceneLoaded += ChangedActiveScene;

    }

    // Update is called once per frame
    void Update() {

        

    }

    private void ChangedActiveScene(Scene scene, LoadSceneMode mode) {
        if (this.gameObject.GetComponent<Score>().previousScene.Equals("DeathScreen") && scene.name.Equals("MainMenu")) {
            canvas = GameObject.Find("Canvas");
            if (this.interstitial.IsLoaded() && !adDisplayed) {
                this.interstitial.Show();
                adDisplayed = true;
            }
        } else if (this.gameObject.GetComponent<Score>().previousScene.Equals("MainGame") && scene.name.Equals("MainMenu")) {
            canvas = GameObject.Find("Canvas");
            if (this.interstitial.IsLoaded() && !adDisplayed) {
                this.interstitial.Show();
                adDisplayed = true;
            }
        }

        if (scene.name.Equals("MainGame")) {
            RequestInterstitial();
        }
    }

    private void RequestInterstitial() {
        #if UNITY_ANDROID
            //string adUnitId = "ca-app-pub-4801663425256116/8643562888";
            string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().AddTestDevice("L2N0219A14006501").Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
        
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs e) {   //When leaving application.
        //interstitial.Destroy();
        print("Ad leaving application");
    }

    public void HandleOnAdClosed(object sender, EventArgs e) {  //when ad is closed by pressing x.
        canvas.SetActive(true);
        interstitial.Destroy();
        adDisplayed = false;
        AC.ResumeAudio();
        print("Ad closed");
        
    }

    public void HandleOnAdOpened(object sender, EventArgs e) {   //When ad is displayed.
        print("Ad opened");
        canvas.SetActive(false);
        AC.PauseAudio();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e) {  //When ad cannot load for some reason.
        print("Ad failed to load: " +  e.Message);
    }

    public void HandleOnAdLoaded(object sender, EventArgs e) {  //When ad is loaded.
        print("Ad loaded");
    }
}
