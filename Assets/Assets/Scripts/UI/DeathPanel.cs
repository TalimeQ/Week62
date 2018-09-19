using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Candy.Control;
using TMPro;

namespace Candy.Ui
{ 
    public class DeathPanel : MonoBehaviour {

             IStartListener restartListener;
            int candyDisplay = 0;
            [SerializeField]
            TextMeshProUGUI finishedScoreText;
            
            private void Awake()
            {
            restartListener = FindObjectOfType<GameController>();
            candyDisplay = FindObjectOfType<ScoreManager>().Score;
            finishedScoreText.text = candyDisplay + " candies";
            }
            public void OnRetryPressed()
            {
            candyDisplay = 0;
            restartListener.OnMenuClicked();
            this.gameObject.SetActive(false);
            }
            public void OnQuitButton()
            {
                Application.Quit();
            }
    }
}