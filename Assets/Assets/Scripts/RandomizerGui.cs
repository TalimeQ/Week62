using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Randomizer))]
public class RandomizerGui : Editor {

    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();


        Randomizer randomizer = (Randomizer)target;

        if (GUILayout.Button("Randomize Scale!"))
        {
            randomizer.RandomizeScale();
        }
        if (GUILayout.Button("Randomize Rotation!"))
        {
            randomizer.RandomizeRotation();
        }
    }

}
