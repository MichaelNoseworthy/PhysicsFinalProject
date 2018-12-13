using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinGravity : MonoBehaviour {

    private Rigidbody rb;
    private bool m_isRunning = false;
    public float PushForce = 100.0f;
    public float m_timeElapsed = 0.0f;
    public float forceDuration = 1.0f;
    public Transform initialPlacement;
    public bool whichPlayer;
    public float distance;

    

    private float staticFrictionForce = 0.6f;
    private float dynamicFrictionForce = 0.5f;

    private float massSphere;
    private float gravity;

    public float getDistance()
    {
        return distance;
    }

    public void setPosition(Vector3 place)
    {
        transform.position = place;
    }

    public void restart()
    {
        m_isRunning = !m_isRunning;
        m_timeElapsed = 0.0f;
    }


    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        distance = (initialPlacement.position.z - transform.position.z);
        gravity = -Physics.gravity.y;
        massSphere = rb.mass;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_isRunning = !m_isRunning;
        }

    }



    private void FixedUpdate()
    {
        if (m_isRunning)
        {
            m_timeElapsed += Time.fixedDeltaTime;
            distance = (transform.position.z - initialPlacement.position.z);
            Debug.Log("Distance: " + distance);
        }
    }
}
