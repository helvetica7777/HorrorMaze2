using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRange : MonoBehaviour
{
    public GameObject noticed;

    public Transform target;
    public Transform monster;
    public LayerMask obstacleMask;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            checkVisibility();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            checkVisibility();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            noticed.SetActive(false);
        }
    }
    void checkVisibility()
    {      
        Vector3 dirToTarget = (target.position - monster.position).normalized;
        float dstToTarget = Vector3.Distance(monster.position, target.position);
        if (!Physics.Raycast(monster.position, dirToTarget, dstToTarget, obstacleMask))
        {
            noticed.SetActive(true);
            transform.parent.GetComponent<AgentWalkScript>().enabled = true;

        }
    }
        
}