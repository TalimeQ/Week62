using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Candy.Control;

namespace Candy.Player
{ 
public class PlayerCollision : MonoBehaviour {

        IPlayerListener playerStateListener;

        void Start () {
            playerStateListener = FindObjectOfType<GameController>();
                
	    }

        // Deathzones trigger
        private void OnTriggerEnter(Collider other)
        {
            switch(other.tag)
            {
                case "KillZone":
                    Debug.Log("You dead boyo");
                    playerStateListener.OnPlayerDeath();
                    // TODO process death differently thats kinda messy
                    Destroy(this.gameObject);
                    break;
                case "Finish":
                    Debug.Log("Finished!");
                    break;
                default:
                    Debug.Log("PlayerCollision :: Unknown Trigger collision, check tag");
                    break;
            }
        }
        public void SignalizeDeath()
        {
            playerStateListener.OnPlayerDeath();
        }
    }
}