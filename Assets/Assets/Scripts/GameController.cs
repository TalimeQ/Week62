using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Candy.Player;

namespace Candy.Control
{
    [Serializable]
    public struct LevelParams
    {
        public Transform spawnPosition;
       
        public GameObject levelToSpawn;
    }
    public class GameController : MonoBehaviour , IPlayerListener {
        [SerializeField]
        GameObject playerPersona;
        [SerializeField]
        List<LevelParams> levelParams = new List<LevelParams>();

        private int  currentLevel = 0;
        public int CurrentLevel { get{ return currentLevel; } set { currentLevel = value; } }


        void LevelStart(int levelToStart = 0)
        {
            // Deactivate old level
            levelParams[currentLevel].levelToSpawn.SetActive(false);

            // Activate new level
            levelParams[levelToStart].levelToSpawn.SetActive(true);
            Transform spawnPosition = levelParams[levelToStart].spawnPosition;

            
            currentLevel = levelToStart;
            GameObject player = Instantiate(playerPersona, spawnPosition.position,Quaternion.identity);
            

        }

        public void OnPlayerDeath()
        {
            Debug.Log("Game Controller Processing death!");
            // Temporary bo jestem kurła idioto
            LevelStart(0);
        }

        public void OnPlayerFinish()
        {
            LevelStart(currentLevel + 1);
        }

        void SpawnPlayer()
        {

        }
    }
}
