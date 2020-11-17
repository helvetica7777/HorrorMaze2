using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class GhostDestroyer : MonoBehaviour
{
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private Animator anim;
    [System.Obsolete]
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.name == "knife")
        {
            gameObject.GetComponent<NavMeshAgent>().Stop(true);
            gameObject.GetComponent<AudioSource>().Play();
            
            gameObject.GetComponent<AgentWalkScript>().alive = false;
            anim.Play("killed");

            Destroy(gameObject,1.5f);
            Destroy(collider.gameObject, 0.5f);
        }
    }
}
