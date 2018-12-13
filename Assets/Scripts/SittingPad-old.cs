using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingPad2 : MonoBehaviour {


    public const int maxForce = 450;
    public int currentForce = 350;
    private bool m_isRunning = false;
    public float m_timeElapsed = 0.0f;
    private bool reverse = false;

    public GameObject forceBar;


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

    public void SetPin1Force()
    {
        //return currentForce;
        GameObject.FindWithTag("Pin2").GetComponent<Pin1>().setForce(currentForce);
        GameObject.FindWithTag("ForceBar").GetComponent<ForceBar>().SetForce((int)currentForce);
        GameObject.FindWithTag("ForceBar").GetComponent<ForceBar>().PinAmount.text = GameObject.FindWithTag("Pin2").GetComponent<Rigidbody>().mass.ToString()
            + " Pounds";
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (sittingOnPad == true)
            SetPin1Force();
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
        if (other.gameObject == Player)
            if (exit)
        {
            sittingOnPad = false;
            Debug.Log("PlayerExitPad");
        }
    }

    private void FixedUpdate()
    {
        if (sittingOnPad == true)
        {
            if (currentForce <= 300)
                reverse = false;
            if (currentForce >= 400)
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
