using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class QTERange : MonoBehaviour
{
    public GameObject QTECanvas;
    public GameObject player;
    public Transform target;
    public Transform monster;
    public LayerMask obstacleMask;

    void Start()
    {
        QTECanvas = GameObject.Find("QTE Canvas");
        player = GameObject.FindWithTag("Player");
        target = player.transform;
        monster = gameObject.transform;
    }
    void Update()
    {
        if (QTECanvas.transform.GetChild(0).gameObject.active)
        {
            QTEController qteController = QTECanvas.transform.GetChild(0).gameObject.GetComponent<QTEController>();
            if (qteController.allpass == 1)
            {
                QTECanvas.transform.GetChild(0).gameObject.SetActive(false);
                Destroy(gameObject);
                player.GetComponent<OpenDoors>().enabled = true;
                player.GetComponent<FirstPersonMovement>().enabled = true;
                player.GetComponent<Crouch>().enabled = true;
                player.transform.Find("camera").GetComponent<FirstPersonLook>().enabled = true;
            }
            else if (qteController.allpass == 2)
            {
                SceneManager.LoadScene("end");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (checkVisibility())
            {
                QTECanvas.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetComponent<NavMeshAgent>().speed = 0.8f;
                player.GetComponent<OpenDoors>().enabled = false;
                player.GetComponent<FirstPersonMovement>().enabled = false;
                player.GetComponent<Crouch>().enabled = false;
                player.transform.Find("camera").GetComponent<FirstPersonLook>().enabled = false;

            }
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Time.timeScale = 1;
    //    }
    //}

    bool checkVisibility()
    {
        Vector3 dirToTarget = (target.position - monster.position).normalized;
        float dstToTarget = Vector3.Distance(monster.position, target.position);
        if (!Physics.Raycast(monster.position, dirToTarget, dstToTarget, obstacleMask))
        {
            return true;
        }
        else return false;
    }

}