using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AgentWalkScript : MonoBehaviour
{
    public Transform destination;
    public Text youdie;
    private NavMeshAgent agent;
    private Animator anim;
    public bool alive;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        destination = GameObject.FindWithTag("Player").transform;
        youdie = GameObject.Find("/Canvas/die").GetComponent<Text>();
        alive = true;
        agent = gameObject.GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (alive)
        {
            anim.Play("flying");
        }
        
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(destination.position - gameObject.transform.position), (2.0f) * Time.deltaTime);
        agent.SetDestination(destination.position);
    }
    
    [System.Obsolete]private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            alive = false;
            anim.Play("scare");
            agent.Stop(true);
            youdie.text="You died";
        }
    }

}
