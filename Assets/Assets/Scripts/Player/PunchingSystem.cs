using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingSystem : MonoBehaviour {

    public float cooldown = 1f;
    public float Distance;

    Animator animate;
    float timer = 0;
    int kidLayer;

    void Awake()
    {
        kidLayer = LayerMask.GetMask("Kid");
        animate = GetComponent<Animator>();
        timer += cooldown;
    }
 
	void Update ()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timer >= cooldown)
            Punch();

	}
    void Punch()
    {
        timer = 0;
        if (Input.GetButtonDown("Fire1"))
            animate.SetTrigger("Punch");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, kidLayer))
        {
            hit.transform.SendMessage("Hit", SendMessageOptions.DontRequireReceiver);
            KidContoller kid = hit.collider.GetComponent<KidContoller>();
            kid.GettingHit();
        }

    }
}
