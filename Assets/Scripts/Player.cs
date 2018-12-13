using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 45; //rotation speed of the player
    [SerializeField] static public float pushForce = 0.0f; //amount to push the player
    private float m_elapsedTime = 0.0f;

    private float JumpPowerupIncrease = 11500;
    public bool powerupActive = false;
    private bool removePowerUp = false;


    private Rigidbody m_rb;

    bool canjump = false;
    float resetPoint = 0;
    Material m_Material;

    private bool m_isAttached = false;

    // Use this for initialization
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_Material = GetComponent<Renderer>().material;
        m_Material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if (!m_isAttached)
        {

            m_rb.velocity = Vector3.zero;
            m_rb.angularVelocity = Vector3.zero;
            m_rb.useGravity = false;

            
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
                m_rb.useGravity = true;

            }
        }
        */
        CheckInput();

        if (powerupActive)
        {
            float pointspeed = 0.7f;
            // The step size is equal to speed times frame time.
            resetPoint += pointspeed * Time.deltaTime;

            if (resetPoint >= 3)
            {
                powerupActive = false;
                resetPoint = 0;
                m_Material.color = Color.red;
            }
        }
    }

    void CheckInput()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (pushForce <= 100)
                pushForce += 50;
            m_rb.AddForce(transform.forward * pushForce, ForceMode.Force);
        }
        else
        {
        }
        //transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (pushForce <= 100)
                pushForce += 50;
            m_rb.AddForce(transform.forward * -pushForce, ForceMode.Force);
        }
        else
        {
        }
        //transform.Translate(Vector3.forward * -movementSpeed * Time.deltaTime);
        if (canjump == true)
        if (Input.GetKey(KeyCode.Space))
        {
                if (powerupActive)
                    m_rb.AddForce(transform.up * (JumpPowerupIncrease + 2000), ForceMode.Force);
                else
                    m_rb.AddForce(transform.up * 2000, ForceMode.Force);

                canjump = false;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    void Catapult()
    {
        m_rb.AddForce(transform.up * 6000, ForceMode.Force);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("PowerUp"))// if the player is touching the gameobject with the Tag ground, the boolean become true
        {
            canjump = true;
        }
        else //if the player is not anymore on the ground, the boolean become false
        {
            canjump = false;
        }

        if (collision.gameObject.CompareTag("JumpPad"))
            Catapult();

        if (collision.gameObject.CompareTag("InitialFall"))
        {
            m_rb.velocity = Vector3.zero;
            m_rb.angularVelocity = Vector3.zero;
            transform.position = GameObject.Find("PlayerInitialSpawn").GetComponent<Transform>().position;
            transform.rotation = GameObject.Find("PlayerInitialSpawn").GetComponent<Transform>().rotation;
        }

        if (collision.gameObject.CompareTag("LavaPit"))
        {
            m_rb.velocity = Vector3.zero;
            m_rb.angularVelocity = Vector3.zero;
            transform.position = GameObject.Find("PlayerInitialSpawn").GetComponent<Transform>().position;
            transform.rotation = GameObject.Find("PlayerInitialSpawn").GetComponent<Transform>().rotation;
        }

        if (collision.gameObject.CompareTag("SecondFallArea"))
        {
            m_rb.velocity = Vector3.zero;
            m_rb.angularVelocity = Vector3.zero;
            transform.position = GameObject.Find("PlayerSecondSpawn").GetComponent<Transform>().position;
            transform.rotation = GameObject.Find("PlayerSecondSpawn").GetComponent<Transform>().rotation;
        }

        if (collision.gameObject.CompareTag("ThirdFallArea"))
        {
            GameObject.Find("DroppingPlatform").GetComponent<DroppingPlatform>().resetPosition();
            m_rb.velocity = Vector3.zero;
            m_rb.angularVelocity = Vector3.zero;
            transform.position = GameObject.Find("PlayerThirdSpawn").GetComponent<Transform>().position;
            transform.rotation = GameObject.Find("PlayerThirdSpawn").GetComponent<Transform>().rotation;
        }

        if (collision.gameObject.CompareTag("RotationTrap"))
        {
            GameObject.Find("DroppingPlatform").GetComponent<DroppingPlatform>().resetPosition();
            m_rb.velocity = Vector3.zero;
            m_rb.angularVelocity = Vector3.zero;
            transform.position = GameObject.Find("PlayerThirdSpawn").GetComponent<Transform>().position;
            transform.rotation = GameObject.Find("PlayerThirdSpawn").GetComponent<Transform>().rotation;
        }



        if (collision.gameObject.CompareTag("PowerUp"))
        {
            GameObject.Find("Powerup").GetComponent<PowerUpScript>().setPosition();
            powerupActive = true;
            m_Material.color = Color.green;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
    }


}