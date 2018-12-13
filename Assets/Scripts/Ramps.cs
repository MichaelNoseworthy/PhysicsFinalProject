using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ramps : MonoBehaviour {

    public  float       sampleTime = 1.0f;
    private Rigidbody   m_rb = null;
    private float       m_elapsedTime = 0.0f;
    private bool        m_isRunning = false;

    private Vector3     m_counterForce;


    // Use this for initialization
    void Start () {
        m_rb = GetComponent<Rigidbody>();
        //m_rb.useGravity = m_isRunning;
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetKeyDown(KeyCode.Space))
        //{
         //   m_isRunning = !m_isRunning;
         //   m_rb.useGravity = m_isRunning;
        //}
	}

    void FixedUpdate()
    {
        
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        //calculate acceleration
        Collider collider = collision.gameObject.GetComponent<Collider>();
        if (collider.material.frictionCombine != PhysicMaterialCombine.Maximum)
        {
            //ignore any collisions with bad physics materials
            return;
        }

        float dynamicFrictionCoeff = collider.material.dynamicFriction;
        Debug.Log("Dynamic Friction Coeff: " + dynamicFrictionCoeff);
        Debug.Log("Mass: " + m_rb.mass);
        Debug.Log("Speed: " + m_rb.velocity.magnitude);
        Vector3 axis;
        float angle;
        collision.transform.rotation.ToAngleAxis(out angle,out axis);
        angle = 90.0f - angle;
        Debug.Log("Angle: " + angle);

        float normalForce = Physics.gravity.magnitude * m_rb.mass * Mathf.Cos(Mathf.Deg2Rad * angle);
        float dynamicFrictionForce = normalForce * dynamicFrictionCoeff;

        float netGravityForce = Physics.gravity.magnitude * m_rb.mass * Mathf.Sin(Mathf.Deg2Rad * angle);
        float netForce = netGravityForce - dynamicFrictionForce;
        //m_counterForce = netForce * collision.transform.;
        float acceleration = netForce / m_rb.mass;
        Debug.Log("acceleration: " + acceleration);
    }*/
}
