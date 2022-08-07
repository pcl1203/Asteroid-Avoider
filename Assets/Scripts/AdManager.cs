using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener
{
   [SerializeField] private bool testMode = true;

#if UNITY_ANDROID
   private string gameId = "4875639";
#elif UNITY_IOS
   private string gameId = "4875638";
#endif

   public static AdManager Instance;
   private GameOverHandler gameOverHandler;
   public void OnInitializationComplete()
   {
      Debug.Log("OnInitializationComplete");
   }

   public void OnInitializationFailed(UnityAdsInitializationError error, string message)
   {
      Debug.LogWarning($"OnInitializationFailed: {message}");
   }

   public void OnUnityAdsShowClick(string placementId)
   {
      Debug.Log("OnUnityAdsShowClick");
   }
   public void ShowAd(GameOverHandler gameOverHandler)
   {
      this.gameOverHandler = gameOverHandler;
      Advertisement.Show("rewardedVideo", this);
   }
   public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
   {

      switch (showCompletionState)
      {
         case UnityAdsShowCompletionState.COMPLETED:
            gameOverHandler.ContinueGame();
            break;
         case UnityAdsShowCompletionState.SKIPPED:
            // Ad Skipped
            break;
         case UnityAdsShowCompletionState.UNKNOWN:
         default:
            Debug.LogWarning("Ad Failed");
            break;

      }
   }

   public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
   {
      Debug.LogWarning($"OnUnityAdsShowFailure: {message}");
   }

   public void OnUnityAdsShowStart(string placementId)
   {
      Debug.Log("OnUnityAdsShowStart");
   }

   private void Awake()
   {
      if (Instance != null && Instance != this)
      {
         Destroy(gameObject);
      }
      else {
         Instance = this;
         DontDestroyOnLoad(gameObject);
         Advertisement.Initialize(gameId, testMode, this);
      }
   }


}
