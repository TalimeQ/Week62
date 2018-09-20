using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Candy.Ui;
using Candy.Player;

public class ParentController : MonoBehaviour
{

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
    public static Transform playerForParent;
    Vector3 playerPosition;
    ScoreManager scoreManager;
    float kucze = 0f;


    Transform parentRigidBody;

    void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        animate = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        parentRigidBody = GetComponent<Transform>();
    }


    void Update()
    {
        if (chaseLeft > 0f)
        {
            chaseLeft -= Time.deltaTime;
            nav.SetDestination(playerForParent.position);
            animate.SetTrigger("ParentGo");
            Debug.Log(chaseLeft);
        }
        else if ((parentRigidBody.position == standardPosition) || kucze > 10f)
        {
            kucze = 0f;
            parentRigidBody.position = standardPosition;
            animate.SetTrigger("ParentStop");
        }
        else if (parentRigidBody.position != standardPosition)
        {
            Debug.Log("wracaj");
            nav.SetDestination(standardPosition);
            //standardPosition.y = parentRigidBody.position.y;
            animate.SetTrigger("ParentGo");
            kucze += Time.deltaTime;
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
                CatchPlayer(other);
        }
    }
    void CatchPlayer(Collider playerCollider)
    {
        playerCollider.GetComponent<PlayerCollision>().SignalizeDeath(playerCollider.gameObject);

    }

}
