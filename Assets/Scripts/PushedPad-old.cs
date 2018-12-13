using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushedPad2 : MonoBehaviour {


    [SerializeField] public GameObject Pin;
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;

    public bool stayedOnPad = false;

    // Use this for initialization
    void Start () {
        Pin = GameObject.FindWithTag("Pin2");

    }
	
	// Update is called once per frame
	void Update () {
		if (stayedOnPad == true)
                GameObject.FindWithTag("Door2").GetComponent<DestroyDoor>().destroyme = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Pin)
            if (enter)
        {
            Debug.Log("entered");
        }
    }

    // stayCount allows the OnTriggerStay to be displayed less often
    // than it actually occurs.
    private float stayCount = 0.0f;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Pin)
        {
            if (stay)
            {
                if (stayCount > 1.0f)
                {
                    Debug.Log("staying");
                    stayCount = stayCount - 0.25f;
                    stayedOnPad = true;
                }
                else
                {
                    stayCount = stayCount + Time.deltaTime;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Pin)
            if (exit)
        {
            Debug.Log("exit");
                stayCount = 0.0f;
        }
    }
}

