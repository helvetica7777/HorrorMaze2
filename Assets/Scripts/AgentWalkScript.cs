using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentWalkScript : MonoBehaviour
{
    public Transform destination;
    public GameObject youdie;
    private NavMeshAgent agent;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(destination.position - gameObject.transform.position), (2.0f) * Time.deltaTime);
        agent.SetDestination(destination.position);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameOver();
        }
    }

    [System.Obsolete]
    public void GameOver()
    {
        agent.Stop(true);
        youdie.SetActive(true);
    }
}
