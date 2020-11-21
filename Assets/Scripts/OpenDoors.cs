using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public DoorStatus ds;
    public GameObject hint;
    public GameObject locked;
    Boolean _hint;
    Animator anim;
    Boolean _double;
    Boolean _canopen;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (_hint)
        {
            if ((Input.GetKeyDown(KeyCode.E))&&(_canopen))
            {
                Debug.Log("E pressed");
                if (_double)
                {
                    anim.Play("pull_double");
                }
                else anim.Play("pull_l");
                hint.SetActive(false);
                _hint = false;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "door")
        {
            _double = true;
            ds = collision.gameObject.transform.parent.parent.GetComponent<DoorStatus>();
            if (ds.canopen == true)
            {
                hint.SetActive(true);
                _hint = true;
                _canopen = true;
            }
            else
            {
                locked.SetActive(true);
                _canopen = false;
            }
            anim = collision.gameObject.transform.parent.parent.GetComponent<Animator>();
        }
        else if (collision.gameObject.tag == "door1")
        {
            _double = false;
            ds = collision.gameObject.transform.parent.parent.GetComponent<DoorStatus>();
            if (ds.canopen == true)
            {
                hint.SetActive(true);
                _hint = true;
                _canopen = true;
            }
            else
            {
                locked.SetActive(true);
                _canopen = false;
            }
            anim = collision.gameObject.transform.parent.parent.GetComponent<Animator>();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if ((collision.gameObject.tag == "door")|| (collision.gameObject.tag == "door1"))
        {
            hint.SetActive(false);
            _hint = false;
            _double = false;
            locked.SetActive(false);
        }
    }

}
