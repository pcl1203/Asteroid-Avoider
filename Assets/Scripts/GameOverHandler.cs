using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
   [SerializeField] private TMP_Text gameText;
   [SerializeField] private GameObject gameOverDisplay;
   [SerializeField] private AsteroidSpawner asteroidSpawner;
   [SerializeField] private ScoreSystem scoreSystem;
   public void PlayAgain()
   {
      SceneManager.LoadScene(1);
   }
   public void ReturnToMenu()
   {
      SceneManager.LoadScene(0);
   }   
   public void EndGame()
   {
      asteroidSpawner.enabled = false;
      gameOverDisplay.gameObject.SetActive(true);

      int finalScore = scoreSystem.EndTimer();
      gameText.text = $"Your Score: {finalScore}";
   }
}
