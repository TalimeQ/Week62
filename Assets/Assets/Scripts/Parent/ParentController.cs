using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Candy.Ui;

public class ParentController : MonoBehaviour {

    [SerializeField]
    float chaseTime = 10f;
    [SerializeField]
    int triggerValue = 100;
    [SerializeField]
    Vector3 standardPosition;
    [SerializeField]
    float catchRange = 1f;
    Animator animate;
    NavMeshAgent nav;
    float chaseLeft = 0f;
    Transform player;
    Vector3 playerPosition;
    ScoreManager scoreManager;

    Rigidbody parentRigidBody;

    void Awake ()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        animate = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        parentRigidBody = GetComponent<Rigidbody>();
    }
	
	
	void Update ()
    {
        if (chaseLeft > 0f)
        {
            chaseLeft -= Time.deltaTime;
            nav.SetDestination(player.position);
            animate.SetTrigger("ParentGo");
        }
        else if (parentRigidBody.transform.position != standardPosition)
        {
            nav.SetDestination(standardPosition);
            standardPosition.y = parentRigidBody.transform.position.y;
            animate.SetTrigger("ParentGo");
        }
        else if((parentRigidBody.transform.position == standardPosition))
        {
            animate.SetTrigger("ParentStop");
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (scoreManager.Score >= triggerValue && chaseLeft == 0f && other.tag == "Player")
        {
            chaseLeft = chaseTime;
            animate.SetTrigger("ParentGo");
        }
    }
    
    void OnTriggerStay(Collider other)
    {
        if (scoreManager.Score >= triggerValue && other.tag == "Player")
        {
            chaseLeft = chaseTime;
                        animate.SetTrigger("ParentGo");
            playerPosition = other.GetComponent<Transform>().position;
            //Debug.Log(Vector3.Distance(playerPosition, transform.position));
            if (Vector3.Distance(playerPosition, transform.position) <= catchRange)
                CatchPlayer();
        }
    }
    void CatchPlayer()
    {
        Debug.Log("zlapany");

    }

}
