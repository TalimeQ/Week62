using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidContoller : MonoBehaviour {

    [SerializeField]
    int candyValue;
    Animator animate;

	void Awake ()
    {
        animate = GetComponent<Animator>();
	}
	

	void Update ()
    {
		
	}

    public void GettingHit()
    {
        animate.SetTrigger("PunchKid");
        animate.SetTrigger("Sit"); // kombinuje jak w miare plynnie przelaczyc miedzy animacjami
        ScoreManager.score += candyValue;

    }
}
