using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Arrow : MonoBehaviour
{

    private int IsFly;
    private int HitsWall;
    private float time;

    private void Start()

    {

        Init();

    }

    public void Init()

    {

        IsFly = 0;
        HitsWall = 0;
        //transform.position = new Vector3(0, 0, -7);

        gameObject.GetComponent<Rigidbody>().isKinematic = false;

        gameObject.GetComponent<Rigidbody>().useGravity = false;

    }

    // Update is called once per frame

    void Update()
    {

        if (IsFly == 0)

        {

            //Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);   

            //Vector3 mousePos = Input.mousePosition;

            //mousePos.z = screenPos.z;  

            //Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            //this.transform.position = worldPos;

            if (Input.GetButtonDown("Fire1"))

            {

                IsFly = 1;
                time = 0;
                this.transform.parent = null;

            }

        }
        else

        {

            time += Time.deltaTime;

        }

    }

    private void FixedUpdate()

    {

        if ((IsFly == 1)&&(HitsWall == 0))

        {

            Rigidbody rigid = this.gameObject.GetComponent<Rigidbody>();

            if (rigid)

            {

                if (time < 0.5)

                {

                    rigid.AddRelativeForce(new Vector3(0, 1, 8));

                }

                else

                {

                    rigid.AddRelativeForce(new Vector3(0, 0, 15));

                    rigid.useGravity = true;

                }

            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag=="wall")|| (collision.gameObject.tag == "door") || (collision.gameObject.tag == "door1"))
        {
            Rigidbody rigid = this.gameObject.GetComponent<Rigidbody>();
            rigid.AddRelativeForce(new Vector3(0, 0, -15));
            HitsWall = 1;

        }
    }

}

