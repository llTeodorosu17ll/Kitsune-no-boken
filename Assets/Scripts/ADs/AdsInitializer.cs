using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    string _gameId = "5252620";
    [SerializeField] bool _testMode = true;

    private int reward = 1;

    public bool adReward = false;

    private int adtry = 1;

    public CoinCollect coinClct;

    public void Awake()
    {
        int a = Random.Range(0, 6);
        Debug.Log(a);
        if (Advertisement.isInitialized && adReward == false && a == 2)
        {
            Debug.Log("Advertisement is Initialized");
            LoadInerstitialAd();
        }
        else
        {
            InitializeAds();
        }
    }


    public void InitializeAds()
    {
        Advertisement.Initialize(_gameId, _testMode, this);
        /*
        adtry++;
        Debug.Log(adtry);
        */
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        LoadInerstitialAd();
        LoadBannerAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads initialization failed: {error.ToString()} - {message}");
    }

    public void LoadInerstitialAd()
    {
        Advertisement.Load("Interstitial_Android", this);
    }

    public void LoadRewardedAd()
    {
        adReward = true;
        Advertisement.Load("Rewarded_Android", this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("OnUnityAdLoaded");
        Advertisement.Show(placementId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {placementId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("OnUnityAdsShowFailure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("OnUnityAdsShowStart");
        Time.timeScale = 0;
        Advertisement.Banner.Hide();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("OnUnityAdsShowClick");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("OnUnityAdsShowComplete" + showCompletionState);
        if (UnityAdsCompletionState.COMPLETED.Equals(showCompletionState))
        {
            Debug.Log("rewared Player");
        }
        Time.timeScale = 1;
        Debug.Log("abiba1");
        Advertisement.Banner.Show("Banner_Android");
    }


    public void LoadBannerAd()
    {
        
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Load("Banner_Android", new BannerLoadOptions { loadCallback=OnBannerLoaded, errorCallback=OnBannerError});
    }

    void OnBannerLoaded()
    {
        Advertisement.Banner.Show("Banner_Android");
    }
    void OnBannerError(string message)
    {

    }

}



