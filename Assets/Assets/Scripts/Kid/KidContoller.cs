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
    AudioSource scream;

	void Awake ()
    {
        animate = GetComponent<Animator>();
        kidHitListener = FindObjectOfType<GameController>();
        scream = GetComponent<AudioSource>();
	}
	

	void Update ()
    {
		
	}

    public void GettingHit()
    {
        animate.SetTrigger("PunchKid");
        scream.Play();
        animate.SetTrigger("Sit"); // kombinuje jak w miare plynnie przelaczyc miedzy animacjami
        kidHitListener.OnKidHit(candyValue, this.gameObject);
    }
}
