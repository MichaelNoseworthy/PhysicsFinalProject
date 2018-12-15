using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public GameObject StartPosition;

    private Rigidbody m_rb;
    private float speed = 10.0f;

    bool moveNow = false;

    float pointspeed = 0.7f;
    // The step size is equal to speed times frame time.
    float resetPoint = 0;

    float randomTime = 3;

    // Use this for initialization
    void Start () {

        m_rb = GetComponent<Rigidbody>();

        randomTime = Random.Range(1.0f, 4.0f);
    }
	
	// Update is called once per frame
	void Update () {

        
        // The step size is equal to speed times frame time.
        resetPoint += pointspeed * Time.deltaTime;

        if (resetPoint >= randomTime)
        {
            moveNow = true;
        }

        if (moveNow == true)
        m_rb.AddForce(transform.right * speed);
    }

    void resetTimer()
    {
        moveNow = false;
        resetPoint = 0;
        randomTime = Random.Range(1.0f, 4.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {

        m_rb.velocity = Vector3.zero;
        m_rb.angularVelocity = Vector3.zero;
        m_rb.rotation = StartPosition.transform.rotation;
        transform.transform.position = StartPosition.transform.position;
        resetTimer();
    }
}
