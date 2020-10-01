using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGenerator : MonoBehaviour
{
    public GameObject ghost;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(ghost, new Vector3(14f, 0.8f, 0), Quaternion.identity);
        Instantiate(ghost, new Vector3(-14f, 0.8f, 0), Quaternion.identity);
        Instantiate(ghost, new Vector3(0, 0.8f, 14f), Quaternion.identity);
    }
}
