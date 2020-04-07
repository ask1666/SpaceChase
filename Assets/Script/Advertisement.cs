using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Advertisement : MonoBehaviour {

    private InterstitialAd interstitial;
    public GameObject loadingScreen;
    public GameObject canvas;
    private bool adDisplayed;

    // Start is called before the first frame update
    void Start() {

        adDisplayed = false;

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        RequestInterstitial();

        

    }

    // Update is called once per frame
    void Update() {

        
        if (this.interstitial.IsLoaded() && !adDisplayed) {
            this.interstitial.Show();
            adDisplayed = true;
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
        loadingScreen.SetActive(true);
        canvas.SetActive(false);
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs e) {
        //interstitial.Destroy();
        print("Ad leaving application");
    }

    public void HandleOnAdClosed(object sender, EventArgs e) {
        canvas.SetActive(true);
        interstitial.Destroy();
        print("Ad closed");
        
    }

    public void HandleOnAdOpened(object sender, EventArgs e) {
        loadingScreen.SetActive(false);
        print("Ad opened");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e) {
        print("Ad failed to load: " +  e.Message);
    }

    public void HandleOnAdLoaded(object sender, EventArgs e) {
        print("Ad loaded");
    }
}
