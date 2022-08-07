using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
   [SerializeField] private GameObject gameOverDisplay;
   [SerializeField] private AsteroidSpawner asteroidSpawner;
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
   }
}
