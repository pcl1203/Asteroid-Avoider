using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
   [SerializeField] private TMP_Text gameText;
   [SerializeField] private GameObject gameOverDisplay;
   [SerializeField] private AsteroidSpawner asteroidSpawner;
   [SerializeField] private ScoreSystem scoreSystem;
   [SerializeField] private GameObject player;
   [SerializeField] private Button continueButton;
   public void PlayAgain()
   {
      SceneManager.LoadScene(1);
   }
   public void ReturnToMenu()
   {
      SceneManager.LoadScene(0);
   }
   public void ContinueButton()
   {
      AdManager.Instance.ShowAd(this);
      continueButton.interactable = false;

   }
   public void EndGame()
   {
      asteroidSpawner.enabled = false;
      gameOverDisplay.gameObject.SetActive(true);

      int finalScore = scoreSystem.EndTimer();
      gameText.text = $"Your Score: {finalScore}";
   }

   internal void ContinueGame()
   {
      scoreSystem.StartTimer();

      asteroidSpawner.enabled = true;

      gameOverDisplay.gameObject.SetActive(false);
      player.transform.position = Vector3.zero;
      player.SetActive(true);

      player.GetComponent<Rigidbody>().velocity = Vector3.zero;
   }
}
