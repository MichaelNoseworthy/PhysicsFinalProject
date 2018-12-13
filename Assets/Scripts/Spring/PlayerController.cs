using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float linearSpeed = 5.0f;
    public float angularSpeed = 45.0f;
    public float jumpSpeed = 15.0f;
    private Rigidbody m_rb = null;

    private bool m_isAttached = false;
	// Use this for initialization
	void Start () {
        m_rb = GetComponent<Rigidbody>();
	}


    
    // Update is called once per frame
    void Update () {

        if (!m_isAttached)
        {
            Vector3 linearVelocity = Input.GetAxis("Vertical") * transform.forward * linearSpeed;
            Vector3 angularVelocity = Input.GetAxis("Horizontal") * transform.up * angularSpeed * Mathf.Deg2Rad;
            linearVelocity.y = m_rb.velocity.y;

            Vector3 jumpVelocity = Input.GetKeyDown(KeyCode.Space) ? transform.up * jumpSpeed : Vector3.zero;
            m_rb.velocity = linearVelocity + jumpVelocity;
            m_rb.angularVelocity = angularVelocity;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //detach

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        CustomSpringComponent colliderSpringComponent = collision.gameObject.GetComponent<CustomSpringComponent>();
        if (colliderSpringComponent)
        {
            colliderSpringComponent.AttachGameObject(this.gameObject);
        }
    }

    
}
