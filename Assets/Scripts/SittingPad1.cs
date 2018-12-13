using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingPad1 : MonoBehaviour {


    
    public int currentForce = 350;
    private bool m_isRunning = false;
    public float m_timeElapsed = 0.0f;
    private bool reverse = false;


    public int maxForce;
    public int minForce;


    public bool Door1 = false;
    public bool Door2 = false;
    public bool Door3 = false;
    public bool Door4 = false;


    [SerializeField] public GameObject Player;
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;

    public bool sittingOnPad = false;

    public void SetForce(int amount)
    {
        currentForce += amount;
    }

    public float GetForce()
    {
        return currentForce;
    }

    public bool GetStatus()
    {
        return sittingOnPad;
    }

    public void SetPinForce()
    {
        if (Door1)
        {
            GameObject.FindWithTag("Pin1").GetComponent<Pin1>().setForce(currentForce);
            GameObject.FindWithTag("ForceBar").GetComponent<ForceBar>().SetForce((int)currentForce);
            GameObject.FindWithTag("ForceBar").GetComponent<ForceBar>().PinAmount.text = GameObject.FindWithTag("Pin1").GetComponent<Rigidbody>().mass.ToString()
                + " Pounds";
        }

        if (Door2)
        {
            GameObject.FindWithTag("Pin2").GetComponent<Pin1>().setForce(currentForce);
            GameObject.FindWithTag("ForceBar").GetComponent<ForceBar>().SetForce((int)currentForce);
            GameObject.FindWithTag("ForceBar").GetComponent<ForceBar>().PinAmount.text = GameObject.FindWithTag("Pin2").GetComponent<Rigidbody>().mass.ToString()
                + " Pounds";
        }

        if (Door3)
        {
            GameObject.FindWithTag("Pin3").GetComponent<Pin1>().setForce(currentForce);
            GameObject.FindWithTag("ForceBar").GetComponent<ForceBar>().SetForce((int)currentForce);
            GameObject.FindWithTag("ForceBar").GetComponent<ForceBar>().PinAmount.text = GameObject.FindWithTag("Pin3").GetComponent<Rigidbody>().mass.ToString()
                + " Pounds";
        }

        if (Door4)
        {
            GameObject.FindWithTag("Pin4").GetComponent<Pin1>().setForce(currentForce);
            GameObject.FindWithTag("ForceBar").GetComponent<ForceBar>().SetForce((int)currentForce);
            GameObject.FindWithTag("ForceBar").GetComponent<ForceBar>().PinAmount.text = GameObject.FindWithTag("Pin4").GetComponent<Rigidbody>().mass.ToString()
                + " Pounds";
        }
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (sittingOnPad == true)
            SetPinForce();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
            if (enter)
        {
                sittingOnPad = true;
                Debug.Log("PlayerOnPad");
            }
    }

    

    private void OnTriggerExit(Collider other)
    {
            if (exit)
        {
            sittingOnPad = false;
            Debug.Log("PlayerExitPad");
        }
    }

    private void FixedUpdate()
    {
        if (Door1)
        if (sittingOnPad == true)
        {
            if (currentForce <= minForce)
                reverse = false;
            if (currentForce >= maxForce)
                reverse = true;

            m_timeElapsed += Time.fixedDeltaTime;
            if (reverse == false && m_timeElapsed >= 0.18)
                SetForce(2);

            if (reverse == true && m_timeElapsed >= 0.18)
                SetForce(-2);

            if (m_timeElapsed >= 0.2)
                m_timeElapsed = 0.0f;
        }

        if (Door2)
            if (sittingOnPad == true)
            {
                if (currentForce <= minForce)
                    reverse = false;
                if (currentForce >= maxForce)
                    reverse = true;

                m_timeElapsed += Time.fixedDeltaTime;
                if (reverse == false && m_timeElapsed >= 0.18)
                    SetForce(2);

                if (reverse == true && m_timeElapsed >= 0.18)
                    SetForce(-2);

                if (m_timeElapsed >= 0.2)
                    m_timeElapsed = 0.0f;
            }

        if (Door3)
            if (sittingOnPad == true)
            {
                if (currentForce <= minForce)
                    reverse = false;
                if (currentForce >= maxForce)
                    reverse = true;

                m_timeElapsed += Time.fixedDeltaTime;
                if (reverse == false && m_timeElapsed >= 0.18)
                    SetForce(2);

                if (reverse == true && m_timeElapsed >= 0.18)
                    SetForce(-2);

                if (m_timeElapsed >= 0.2)
                    m_timeElapsed = 0.0f;
            }

        if (Door4)
            if (sittingOnPad == true)
            {
                if (currentForce <= minForce)
                    reverse = false;
                if (currentForce >= maxForce)
                    reverse = true;

                m_timeElapsed += Time.fixedDeltaTime;
                if (reverse == false && m_timeElapsed >= 0.18)
                    SetForce(2);

                if (reverse == true && m_timeElapsed >= 0.18)
                    SetForce(-2);

                if (m_timeElapsed >= 0.2)
                    m_timeElapsed = 0.0f;
            }
    }
}
