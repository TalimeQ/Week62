using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingSystem : MonoBehaviour {

    int kid;
    public float Distance;
    void Awake()
    {
        kid = LayerMask.GetMask("Kid");

    }
 
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, kid))
            {
                hit.transform.SendMessage("Hit", SendMessageOptions.DontRequireReceiver);
                
            }


        }

	}
}
