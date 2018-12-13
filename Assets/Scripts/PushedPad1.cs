using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushedPad1 : MonoBehaviour {


    [SerializeField] public GameObject Pin;
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;

    public bool Door1 = false;
    public bool Door2 = false;
    public bool Door3 = false;
    public bool Door4 = false;

    public float MaxTimeOnPad;

    public bool stayedOnPad = false;

    //For changing the colour of the object
    Material m_Material;

    // Use this for initialization
    void Start () {

        m_Material = GetComponent<Renderer>().material;

        m_Material.color = Color.red;

        if (Door1)
            Pin = GameObject.FindWithTag("Pin1");

        if (Door2)
            Pin = GameObject.FindWithTag("Pin2");

        if (Door3)
            Pin = GameObject.FindWithTag("Pin3");

        if (Door4)
            Pin = GameObject.FindWithTag("Pin4");

        //if (Door4)
        //Pin = GameObject.FindWithTag("Pin4");

    }
	
	// Update is called once per frame
	void Update () {
        if (Door1)
		if (stayedOnPad == true)
                GameObject.FindWithTag("Door1").GetComponent<DestroyDoor>().destroyme = true;

        if (Door2)
            if (stayedOnPad == true)
                GameObject.FindWithTag("Door2").GetComponent<DestroyDoor>().destroyme = true;

        if (Door3)
            if (stayedOnPad == true)
                GameObject.FindWithTag("Door3").GetComponent<DestroyDoor>().destroyme = true;

        if (Door4)
            if (stayedOnPad == true)
            {
                GameObject.FindWithTag("ForceBar").GetComponent<ForceBar>().WinGame();
                GameObject.FindWithTag("ForceBar").GetComponent<ForceBar>().GamePaused = true;
            }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Pin)
            if (enter)
        {
            Debug.Log("entered");
                m_Material.color = Color.green;
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
                if (stayCount > MaxTimeOnPad)
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
                m_Material.color = Color.red;
            }
    }
}

