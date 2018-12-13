using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin1 : MonoBehaviour {

    private Rigidbody rb;
    private bool m_isRunning2 = false;
    private bool timer_isRunning2 = false;
    public float PushForce = 350.0f;
    //public float m_timeElapsed = 0.0f;
    public float m_timeElapsed2 = 0.0f;
    public float forceDuration = 1.0f;
    public float timerDuration = 15.0f;
    public GameObject SittingPad;
    public bool PadStatus = false;
    public bool stayedOnPad1 = false;
    public Transform initialPlacement;

    private float staticFrictionForce = 0.6f;
    private float dynamicFrictionForce = 0.5f;

    private float massSphere;
    private float gravity;

    public float Timer = 0.0f;

    public bool Door1 = false;
    public bool Door2 = false;
    public bool Door3 = false;
    public bool Door4 = false;

    public void setForce(float amount)
    {
        PushForce = amount;
    }

    public float getForce()
    {
        return PushForce;
    }

    public void setPosition(Vector3 initialPlacement)
    {
        //transform.position = initialPlacement;
    }

    public void restart()
    {
       // m_isRunning = !m_isRunning;
    }


    void Start () {
        rb = GetComponent<Rigidbody>();
        gravity = -Physics.gravity.y;
        massSphere = rb.mass;
        if (Door1)
        PadStatus = GameObject.FindWithTag("Pad1").GetComponent<SittingPad1>().GetStatus();

        if (Door2)
            PadStatus = GameObject.FindWithTag("Pad2").GetComponent<SittingPad1>().GetStatus();

        if (Door3)
            PadStatus = GameObject.FindWithTag("Pad3").GetComponent<SittingPad1>().GetStatus();

        if (Door4)
            PadStatus = GameObject.FindWithTag("Pad4").GetComponent<SittingPad1>().GetStatus();
    }
	
	// Update is called once per frame
	void Update () {

        if (Door1)
            PadStatus = GameObject.FindWithTag("Pad1").GetComponent<SittingPad1>().GetStatus();

        if (Door2)
            PadStatus = GameObject.FindWithTag("Pad2").GetComponent<SittingPad1>().GetStatus();

        if (Door3)
            PadStatus = GameObject.FindWithTag("Pad3").GetComponent<SittingPad1>().GetStatus();

        if (Door4)
            PadStatus = GameObject.FindWithTag("Pad4").GetComponent<SittingPad1>().GetStatus();

        if (PadStatus == true)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_isRunning2 = !m_isRunning2;
            timer_isRunning2 = true;
            }

        if (m_isRunning2)
        {
            m_timeElapsed2 += Time.deltaTime;
            rb.AddForce(transform.forward * PushForce, ForceMode.Force);


            if (m_timeElapsed2 > forceDuration)
            {
                //transform.position = initialPlacement.position;
                m_isRunning2 = false;
                //Debug.Log("Velocity: " + rb.velocity.z);
                m_timeElapsed2 = 0.0f;
            }

            
        }
    }

    protected float CalculateForce()
    {
        float force = 0.0f;
        float weight = massSphere * gravity;
        float frictionForceNeeded = weight * dynamicFrictionForce;
        return force;
    }

        private void FixedUpdate()
    {
        if (timer_isRunning2 == true)
            Timer = Timer + Time.fixedDeltaTime;

        if (Timer > timerDuration)
        {
            timer_isRunning2 = false;
            Timer = 0.0f;
            transform.position = initialPlacement.position;
        }
    }


}
