using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Candy.Control;
namespace Candy.Ui
{ 
public class PausedMenu : MonoBehaviour, IPlayerListener {

        IStartListener restartListener;

 
        private void ToggleMenuFunc()
        {
            if(this.gameObject.activeInHierarchy == false)
            {
                this.gameObject.SetActive(true);
                print("pausing 2    " + Time.timeScale);
                Time.timeScale = 0.0f;
            }
            else
            {
                this.gameObject.SetActive(false);
                print("pausing 3    " + Time.timeScale);
                Time.timeScale = 1.0f;
            }
        }
    
        private void Awake()
        {
            restartListener = FindObjectOfType<GameController>();
            print("pausing 1   " + Time.timeScale);
            Time.timeScale = 0.0f;

        }
        public void OnRetryPressed()
        {
            restartListener.OnMenuClicked();
            this.gameObject.SetActive(false);
        }
        public void OnQuitButton()
        {
            Application.Quit();
        }

        public void OnEscapePressed()
        {
            ToggleMenuFunc();
        }

    }
}