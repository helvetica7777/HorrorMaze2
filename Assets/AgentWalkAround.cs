using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class AgentWalkAround : MonoBehaviour
{
    public GameObject[] destination;
    private NavMeshAgent agent;
    private int speed;
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(destination[0].transform.position);
    }
    void Upddate()
    {
        if (transform.position == destination[0].transform.position)
        {
            agent.SetDestination(destination[1].transform.position);
        }
        else if (transform.position == destination[1].transform.position)
        {
            agent.SetDestination(destination[0].transform.position);
        }
        //for (int i = 0; i < destination.Length; i++)
        //{
        //    if (transform.position == destination[i].transform.position)
        //    {
        //        Debug.Log("Yes");
        //        //gotoNext(i);
        //    }
        //}
    }
    //void gotoNext(int i)
    //{
    //    if ((i == 0) || (i == destination.Length - 1))
    //    {
    //        speed *= -1;
    //    }
    //    agent.SetDestination(destination[i+speed].transform.position);

    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "turnpoint")
    //    {
    //        print(other.gameObject.name);
    //        if ((n==0) || (n == destination.Length-1))
    //        {
    //            speed *= -1;
    //        }
    //        n = n + speed;


    //        agent.SetDestination(destination[n].transform.position);
    //    }
    //}
}
