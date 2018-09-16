using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Randomizer : MonoBehaviour {

    [Header("Scale Random Values")]
    [Tooltip("Max X Scale")]
    [SerializeField]
    float maxXScale = 1;
    [Tooltip("Max Y Scale")]
    [SerializeField]
    float maxYScale = 1;
    [Tooltip("Max Z Scale")]
    [SerializeField]
    float maxZScale = 1;
    [Tooltip("")]
    [SerializeField]
    bool keepScale = true;


    [Header("Rotation")]
    [Tooltip("If checked, the object rotation will only change in Y axis")]
    [SerializeField]
    bool onlyYRot = true;
    [SerializeField]
    float minYRange = 0;
    [SerializeField]
    float maxYRange = 360;
    [SerializeField]
    float minZRange = 0;
    [SerializeField]
    float maxZRange = 360;
    [SerializeField]
    float minXRange = 0;
    [SerializeField]
    float maxXRange = 360;





    public void RandomizeRotation()
    {
       
        Vector3 newRot = new Vector3();
        if (onlyYRot)
        {
            newRot.y = Random.Range(minYRange, maxYRange);
        }
        else
        {
            newRot.x = Random.Range(minXRange, maxXRange);
            newRot.y = Random.Range(minYRange, maxYRange);
            newRot.z = Random.Range(minZRange, maxZRange);
        }
        this.transform.rotation = Quaternion.Euler(newRot);
    }

    public void RandomizeScale()
    {
        GameObject randomizedObj = GetComponent<GameObject>();
        Vector3 randomScale = new Vector3();
        
        if (keepScale)
        {
            float rawNewScale = Random.Range(0, maxXScale);
            randomScale.x = rawNewScale;
            randomScale.y = rawNewScale;
            randomScale.z = rawNewScale;
        }
        else
        {
            randomScale.x = Random.Range(0, maxXScale);
            randomScale.y = Random.Range(0, maxYScale);
            randomScale.z = Random.Range(0, maxZScale);
        }
    
        this.transform.localScale = randomScale;
    }
   
}
