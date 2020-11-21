using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;

public class QTEController : MonoBehaviour
{
    public GameObject DisplayBox;
    public GameObject PassBox;
    public int number;
    //public GameObject QTECanvas;
    int qteGen;
    int waitingforkey;
    int CorrectKey;
    int countingDown;
    public int allpass;

    void Start()
    {
        //QTECanvas = GameObject.Find("QTE Canvas");
        //DisplayBox = QTECanvas.transform.GetChild(2).gameObject;
        //PassBox = QTECanvas.transform.GetChild(3).gameObject;
        waitingforkey = 0;
        number = 0;
        allpass = 0;
    }

    void Update()
    {
        if (waitingforkey == 0)
        {         
            if (number < 6)
            {
                qteGen = UnityEngine.Random.Range(1, 6);
                number = number + 1;
                countingDown = 1;
                StartCoroutine(CountDown());

                if (qteGen == 1)
                {
                    waitingforkey = 1;
                    DisplayBox.GetComponent<Text>().text = "[Q]";
                }
                if (qteGen == 2)
                {
                    waitingforkey = 2;
                    DisplayBox.GetComponent<Text>().text = "[F]";
                }
                if (qteGen == 3)
                {
                    waitingforkey = 3;
                    DisplayBox.GetComponent<Text>().text = "[R]";
                }
                if (qteGen == 4)
                {
                    waitingforkey = 4;
                    DisplayBox.GetComponent<Text>().text = "[T]";
                }
                if (qteGen == 5)
                {
                    waitingforkey = 5;
                    DisplayBox.GetComponent<Text>().text = "[Y]";
                }
            }
            else
            {
                allpass = 1;
            }

            
        }

        if (qteGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("QKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (qteGen == 2)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("FKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (qteGen == 3)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("RKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (qteGen == 4)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("TKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (qteGen == 5)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("YKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }

    IEnumerator KeyPressing()
    {
        qteGen = 6;
        if (CorrectKey == 1)
        {
            countingDown = 2;
            PassBox.GetComponent<Image>().color = UnityEngine.Color.green;
            yield return new WaitForSeconds(0.75f);
            CorrectKey = 0;
            PassBox.GetComponent<Image>().color = UnityEngine.Color.grey;
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(0.5f);
            waitingforkey = 0;
            countingDown = 1;
        }
        if (CorrectKey == 2)
        {
            countingDown = 2;
            PassBox.GetComponent<Image>().color = UnityEngine.Color.red;
            yield return new WaitForSeconds(0.75f);
            CorrectKey = 0;
            //PassBox.GetComponent<Image>().color = UnityEngine.Color.grey;
            //DisplayBox.GetComponent<Text>().text = "";
            //yield return new WaitForSeconds(0.5f);
            waitingforkey = 0;
            countingDown = 1;
            number = 0;
            allpass = 2;
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1.0f);
        if (countingDown == 1)
        {
            qteGen = 6;
            countingDown = 2;
            PassBox.GetComponent<Image>().color = UnityEngine.Color.red;
            yield return new WaitForSeconds(0.75f);
            CorrectKey = 0;
            //PassBox.GetComponent<Image>().color = UnityEngine.Color.grey;
            //DisplayBox.GetComponent<Text>().text = "";
            //yield return new WaitForSeconds(0.5f);
            waitingforkey = 0;
            countingDown = 1;
            number = 0;
            allpass = 2;
        }
    }
}
