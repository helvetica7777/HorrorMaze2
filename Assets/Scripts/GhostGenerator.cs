using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGenerator : MonoBehaviour
{
    public GameObject ghost;
    public GameObject bgm1;
    public Vector3 position;
    AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        bgm = bgm1.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(ghost, position, Quaternion.identity);
            bgm.Play();
            //Instantiate(ghost, new Vector3(-14f, 0.8f, 0), Quaternion.identity);
            //Instantiate(ghost, new Vector3(0, 0.8f, 14f), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
