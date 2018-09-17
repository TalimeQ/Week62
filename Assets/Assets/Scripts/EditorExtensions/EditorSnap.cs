using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour {

    [Header("Snap Values")]
    [Tooltip("Use if YxY square grid, uses xSnap if true")]
    [SerializeField] bool gridRectSnap = false;
    [Tooltip("Should it have Y movement allowed")]
    [SerializeField] bool turnYSnap = false;
    [Tooltip("Editor Snap in X axis")]
    [SerializeField] float xSnap = 10;
    [Tooltip("Editor Snap in Y axis")]
    [SerializeField] float ySnap = 10;
    [Tooltip("Editor Snap in Z axis")]
    [SerializeField] float zSnap = 10;
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SnapGridPosition();
	}
    void SnapGridPosition()
    {
        Vector3 gridPosition = CalculateGridPos();
        transform.position = CalculateSnap(gridPosition);
    }

    private Vector3 CalculateSnap(Vector3 gridPos)
    {
       if(gridRectSnap)
       {
            if (turnYSnap) return new Vector3(gridPos.x * xSnap, gridPos.y * xSnap, gridPos.z * xSnap);
            return new Vector3(gridPos.x * xSnap, 0, gridPos.z * xSnap);
       }
        else
        {
            if (turnYSnap) return new Vector3(gridPos.x * xSnap, gridPos.y * ySnap, gridPos.z * zSnap);
                    return new Vector3(gridPos.x * xSnap, 0, gridPos.z * zSnap);
        }
    }
     

    

    private Vector3 CalculateGridPos()
    {
        int ySnapPos = 0;
        int xSnapPos = 0;
        int zSnapPos = 0;
        if (gridRectSnap)
        {
            xSnapPos = Mathf.RoundToInt(transform.position.x / xSnap);
            zSnapPos = Mathf.RoundToInt(transform.position.z / xSnap);
            if (turnYSnap) ySnapPos = Mathf.RoundToInt(transform.position.y / xSnap); 

        }
        else
        {
            xSnapPos = Mathf.RoundToInt(transform.position.x / xSnap);
            zSnapPos = Mathf.RoundToInt(transform.position.z / zSnap);
            if (turnYSnap) ySnapPos = Mathf.RoundToInt(transform.position.y / ySnap);
        }
        return new Vector3(xSnapPos, ySnapPos, zSnapPos);
    }
}
