using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Candy.Ui
{ 
public class MenuController : MonoBehaviour {

        [SerializeField]
        GameObject startPanel;
        [SerializeField]
        GameObject deathMenu;
        [SerializeField]
        GameObject pauseMenu;

	    void Start ()
        {
		    if(startPanel == null)
            {
                    Debug.Log("Menu controller :: Start panel is null");
                    return;
            }
            else
            {
                startPanel.SetActive(true);
            }
	    }
	    public void ShowDeathMenu()
        {
            deathMenu.SetActive(true);
        }
        public void ShowPauseMenu()
        {
            pauseMenu.SetActive(true);
        }
}
}