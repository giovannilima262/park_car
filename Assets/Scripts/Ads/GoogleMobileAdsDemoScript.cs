using UnityEngine;
using GoogleMobileAds.Api;
public class GoogleMobileAdsDemoScript : MonoBehaviour
{
    public void Start()
    {
        // When true all events raised by GoogleMobileAds will be raised
        // on the Unity main thread. The default value is false.
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus =>
        {
            AdsBannerView.Instance.LoadAd();
            AdsInterstitialView.Instance.LoadInterstitialAd();
            AdsRewardedView.Instance.LoadRewardedAd();
        });
    }
}