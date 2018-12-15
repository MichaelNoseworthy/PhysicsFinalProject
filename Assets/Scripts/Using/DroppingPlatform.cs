using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingPlatform : MonoBehaviour {

    //private Rigidbody m_rb;

    public bool falldown = false;
    private float speed = 2;
    Vector3 end;
    public float dropPoint = 0;
    public GameObject RestartPosition;

    public Transform target;
    // Use this for initialization
    void Start () {
        //m_rb = GetComponent<Rigidbody>();
        //m_rb.useGravity = false;
        end = GameObject.Find("Falls/FallThirdArea").transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
        if (falldown == true)
        {
            float pointspeed = 0.7f;
            // The step size is equal to speed times frame time.
            dropPoint += pointspeed * Time.deltaTime;
            if (dropPoint >= 1)
            {
                // The step size is equal to speed times frame time.
                float step = speed * Time.deltaTime;

                // Move our position a step closer to the target.
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
        }
        //Vector3.MoveTowards(transform.position, end, speed * Time.deltaTime);


    }

    void fallingdown()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            falldown = true;
        }
    }

    public void resetPosition()
    {
        falldown = false;
        transform.position = RestartPosition.transform.position;
        transform.rotation = RestartPosition.transform.rotation;
    }

}
