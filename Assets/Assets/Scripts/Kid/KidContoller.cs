using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Candy.Gameplay;
using Candy.Control;

public class KidContoller : MonoBehaviour {

    [SerializeField]
    int candyValue;
    Animator animate;
    IKidListener kidHitListener;


	void Awake ()
    {
        animate = GetComponent<Animator>();
        kidHitListener = FindObjectOfType<GameController>();
	}
	

	void Update ()
    {
		
	}

    public void GettingHit()
    {
        animate.SetTrigger("PunchKid");
        animate.SetTrigger("Sit"); // kombinuje jak w miare plynnie przelaczyc miedzy animacjami
        ScoreManager.score += candyValue;
        kidHitListener.OnKidHit();
    }
}
