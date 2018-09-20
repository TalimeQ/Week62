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
    public class GameController : MonoBehaviour , Candy.Player.IPlayerListener , IKidListener, IStartListener  {

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
        [SerializeField]
        GameObject kidPersona;
        [SerializeField]
        int kidCount = 20;
        [SerializeField]
        List<Transform> kidSpawns = new List<Transform>();


        private int  currentLevel = 0;
        public int CurrentLevel { get{ return currentLevel; } set { currentLevel = value; } }

        void Start()
        {
           
        }
        void LevelStart(int levelToStart = 0)
        {
            
            scoreText.gameObject.SetActive(true);
            scoreManager.Score = 0;
            scoreManager.UpdateScore(0);

            Transform spawnPosition = PlayerSpawns[UnityEngine.Random.Range(0, PlayerSpawns.Count)];
           

            currentLevel = levelToStart;
            GameObject player = Instantiate(playerPersona, spawnPosition.position,Quaternion.identity);
            for(int i=0; i<kidCount;i++)
            {
                spawnPosition = kidSpawns[UnityEngine.Random.Range(0, kidSpawns.Count)];
                GameObject kid = Instantiate(kidPersona, spawnPosition.position, Quaternion.identity);

            }
            ParentController.playerForParent = GameObject.FindGameObjectWithTag("Player").transform;
            Debug.Log(player);

        }

        public void OnPlayerDeath(GameObject player)
        {
            scoreText.gameObject.SetActive(false);
            menuController.ShowDeathMenu();
            GameObject[] massacre;
            massacre = GameObject.FindGameObjectsWithTag("Kid");
            
            foreach (GameObject kid in massacre)
            {
                Destroy(kid);
            }
            Destroy(player);
            

        }

        public void OnPlayerFinish()
        {
            LevelStart(currentLevel + 1);
        }

        void SpawnPlayer()
        {

        }

        public void OnKidHit(int candyValue, GameObject kid)
        {
            scoreManager.UpdateScore(candyValue);
            Invoke("RespawnKid", 10);
            StartCoroutine(TimedDestruction(kid, 2f));

        }
        IEnumerator TimedDestruction(GameObject timedObject, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            Destroy(timedObject);

        }
        void RespawnKid()
        {
            Transform spawnPosition;
            spawnPosition = kidSpawns[UnityEngine.Random.Range(0, kidSpawns.Count)];
            GameObject kid = Instantiate(kidPersona, spawnPosition.position, Quaternion.identity);
        }

        public void OnMenuClicked()
        {
            LevelStart(0);
        }
        public void OnPauseMenu()
        {
            menuController.ShowPauseMenu();
            Time.timeScale = 0;
        }

    }
}
