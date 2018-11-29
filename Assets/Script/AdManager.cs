using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AdManager : MonoBehaviour
{

#if UNITY_ANDROID
    string appId = "ca-app-pub-6329866637736006~4555818148";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-6329866637736006~4555818148";
#else
            string appId = "unexpected_platform";
#endif
    private RewardBasedVideoAd rewardBasedVideo;
    public int VideoReward = 0;
    public int AdOn = 0;
    public bool Loading = false;
    void Start()
    {
        MobileAds.Initialize(appId);
    }

    public void ShowAd()
    {
        StartCoroutine(ShowAdCore());
    }

    IEnumerator ShowAdCore()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-6329866637736006/2315623374";
#elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
                string adUnitId = "unexpected_platform";
#endif
        InterstitialAd interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.s
        interstitial.LoadAd(request);
        //wait until loaded
        while (!interstitial.IsLoaded())
            yield return null;

        interstitial.Show();
        AdOn = 1;
    }

    public void ShowVideo()
    {
        StartCoroutine(VideoCore());
    }

    private IEnumerator VideoCore()
    {
        Loading = true;
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-6329866637736006/2315623374";
#elif UNITY_IPHONE
                    string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
                    string adUnitId = "unexpected_platform";
#endif
        rewardBasedVideo = RewardBasedVideoAd.Instance;
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        rewardBasedVideo.LoadAd(request, adUnitId);

        while (!rewardBasedVideo.IsLoaded())
            yield return null;

        rewardBasedVideo.Show();
        AdOn = 1;
    }
    private void HandleRewardBasedVideoRewarded(object sender, Reward e)
    {
        VideoReward = 1;
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        Loading = false;
    }
}
