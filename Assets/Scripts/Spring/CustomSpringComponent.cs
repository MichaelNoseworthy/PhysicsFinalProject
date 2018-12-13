using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpringJoint))]

public class CustomSpringComponent : MonoBehaviour {


    private Rigidbody m_rb = null;
    private SpringJoint m_springJoint = null;

	// Use this for initialization
	void Start () {
        m_rb = GetComponent<Rigidbody>();
        m_springJoint = GetComponent<SpringJoint>();

        //Hook's Law F = -kx
        //or x = F/k
        float forceApplied = m_rb.mass * Physics.gravity.y;
        float displacement = forceApplied / m_springJoint.spring;
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = this.transform.position + (this.transform.up * displacement);
        sphere.transform.localScale *= 0.2f;
        sphere.GetComponent<Collider>().enabled = false;


        //spring-damper system: 
        //F = -kx - bv
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool AttachGameObject(GameObject obj)
    {
        if (m_springJoint.connectedBody)
        {
            return false;
        }
        Rigidbody objectRb = obj.GetComponent<Rigidbody>();
        if (!objectRb)
        {
            return false;
        }


        m_springJoint.connectedBody = objectRb;
        return true;
    }
}
