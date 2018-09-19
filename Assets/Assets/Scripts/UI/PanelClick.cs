using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Candy.Control;

namespace Candy.Ui { 

    public class PanelClick : MonoBehaviour {

        [SerializeField]
        GameController gameController;
        IStartListener menuStartListener;

        private void Awake()
        {
            if (gameController == null) gameController = FindObjectOfType<GameController>();
            menuStartListener = gameController;

        }

        public void OnPanelClick()
        {
            this.gameObject.SetActive(false);
            print("Game started");
            menuStartListener.OnMenuClicked();
        }
    }
}