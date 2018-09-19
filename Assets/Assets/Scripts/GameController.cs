using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Candy.Gameplay;
using Candy.Player;
using Candy.Ui;
using TMPro;

namespace Candy.Control
{
    [Serializable]
    public struct LevelParams
    {
        public Transform spawnPosition;
       
        public GameObject levelToSpawn;
    }
    public class GameController : MonoBehaviour , IPlayerListener , IKidListener, IStartListener  {

        [SerializeField]
        GameObject playerPersona;
        [SerializeField]
        List<LevelParams> levelParams = new List<LevelParams>();
        [SerializeField]
        ScoreManager scoreManager;
        [SerializeField]
        MenuController menuController;
        [SerializeField]
        TextMeshProUGUI scoreText;
        [SerializeField]
        List<Transform> PlayerSpawns = new List<Transform>();


        private int  currentLevel = 0;
        public int CurrentLevel { get{ return currentLevel; } set { currentLevel = value; } }

        void Start()
        {
           
        }
        void LevelStart(int levelToStart = 0)
        {
            scoreText.gameObject.SetActive(true);

            Transform spawnPosition = PlayerSpawns[UnityEngine.Random.Range(0, PlayerSpawns.Count)];
           

            currentLevel = levelToStart;
            GameObject player = Instantiate(playerPersona, spawnPosition.position,Quaternion.identity);
            Debug.Log(player);

        }

        public void OnPlayerDeath()
        {
            scoreText.gameObject.SetActive(false);
            menuController.ShowDeathMenu();
          
        }

        public void OnPlayerFinish()
        {
            LevelStart(currentLevel + 1);
        }

        void SpawnPlayer()
        {

        }

        public void OnKidHit(int candyValue)
        {
                scoreManager.UpdateScore(candyValue);
                Invoke("RespawnKid", 10);
        }
        
        void RespawnKid()
        {

        }

        public void OnMenuClicked()
        {
            LevelStart(0);
        }
    }
}
