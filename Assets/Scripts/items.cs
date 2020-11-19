using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{
    public int knives=0;
    GameObject[] knife;
    public GameObject prefab;
    private void Update()
    {
        knife = GameObject.FindGameObjectsWithTag("knife");
        if (knives != 0)
        {
            if (knife.Length==0)
            {
                Instantiate(prefab, transform);
                Debug.Log("reload");
            }
           
        }
    }
}
