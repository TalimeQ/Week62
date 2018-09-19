using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Candy.Ui
{ 
public class ScoreManager : MonoBehaviour {


        [SerializeField]
        TextMeshProUGUI scoreText;
        int score = 0;
        public int Score { get { return score; } }
        public void ResetScore()
        {
            score = 0;
        }
        public void UpdateScore(int scoreToAdd)
        {
                if(!scoreText)
                {
                    Debug.Log("Ustaw referencje do TMPro cwelu.");
                    return;
                }
                score += scoreToAdd;
                scoreText.text = "Score: " + score;
        }
}
}
