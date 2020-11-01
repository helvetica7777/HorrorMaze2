using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class GhostDestroyer : MonoBehaviour
{

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.name == "Candle")
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 0;
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject,1.5f);
            Destroy(collider.gameObject, 0.5f);
        }
    }
}
