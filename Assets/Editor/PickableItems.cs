using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class PickableItems : EditorWindow
{ 
    public GameObject selectedObject;
    string xOffset = string.Empty;
    string yOffset = string.Empty;
    string zOffset = string.Empty;
    Vector3 valuePos;
    float x, y, z=0; 
    List<GameObject> posList = new List<GameObject>();
    List<GameObject> itemList = new List<GameObject>(); 

    [MenuItem("Selection/Pickable Items")]
   private static void ShowWindow()
    {
        var window = GetWindowWithRect<PickableItems>(new Rect(0, 0, 500, 400));
        window.Show();
    }
    void OnGUI()
    { 
        GUILayout.BeginHorizontal();
        selectedObject = (GameObject)EditorGUILayout.ObjectField(selectedObject, typeof(object), true);
        GUILayout.EndHorizontal();

        GUILayout.BeginVertical();
   
        xOffset = EditorGUILayout.TextField("x Offset:", xOffset == string.Empty ? "0" : xOffset);
        yOffset = EditorGUILayout.TextField("y Offset:", yOffset == string.Empty ? "0" : yOffset);
        zOffset = EditorGUILayout.TextField("z Offset:", zOffset == string.Empty ? "0" : zOffset);
        
        GUILayout.EndVertical();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Apply"))
        {
            if (itemList != null)
            {
                Clean();
                Reset();
            }
            apply();
        }
        if (GUILayout.Button("Reset"))
        {
            Reset();
        }
        if (GUILayout.Button("Clean"))
        {
            Clean();
        }
        GUILayout.EndHorizontal(); 
    }
    void apply()
    { 
        Transform[] transforms = Selection.transforms;
        try 
        {
            x = float.Parse(xOffset);
        }
        catch (Exception FormatException)
        {
            Debug.Log("default setting");
        }
        try
        {
            y = float.Parse(yOffset);
        }
        catch (Exception FormatException)
        {
            Debug.Log("default setting");
        }
        try
        {
            z = float.Parse(zOffset);
        }
        catch (Exception FormatException)
        {
            Debug.Log("default setting");
        }

        valuePos = new Vector3(x,y,z);

        for (int i = 0; i < transforms.Length; i++)
        {
            posList.Add(transforms[i].gameObject); 
        }
        foreach (GameObject value in posList)
        {
            GameObject it = Instantiate(selectedObject, valuePos + value.transform.position, Quaternion.identity);
            itemList.Add(it); 
        }
      
    }
    void Clean()
    {
        try
        {
            foreach (GameObject i in itemList)
            {
                Debug.Log(i.name + ":" + i.transform.position);
                Undo.DestroyObjectImmediate(i);
            }
        }
        catch 
        { 

        }

    }
    void Reset()
    { 
        posList = new List<GameObject>();
        itemList = new List<GameObject>();
    }
}
