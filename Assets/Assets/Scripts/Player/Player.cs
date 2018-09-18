using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Candy.Player { 

    public class Player : MonoBehaviour {

        [SerializeField]
        Vector3 cameraOffset;
         public Vector3 CameraOffset { get { return cameraOffset; } set { cameraOffset = value; } }
        Camera mainCamera;

       
	    
	    void Start () {
            
         mainCamera =  Camera.main;
            
            if( cameraOffset == null)
            {
                cameraOffset = new Vector3(0, 0, 0);
            }
        }
	
	    // Update is called once per frame
	    void Update () {

            UpdateCameraPos();
	    }
        void UpdateCameraPos()
        {
            mainCamera.transform.position = this.gameObject.transform.position + CameraOffset;
        }
    }
}
