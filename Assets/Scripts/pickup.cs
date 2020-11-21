using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public GameObject hint2;
    private bool _hint;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_hint)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E pressed");
                PickupKnife();
                hint2.SetActive(false);
                _hint = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hint2.SetActive(true);
            _hint=true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        hint2.SetActive(false);
        _hint = false;

    }
    void PickupKnife()
    {
        player.GetComponent<items>().knives += 1;
        Destroy(gameObject);
    }
}
