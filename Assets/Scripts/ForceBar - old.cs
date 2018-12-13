using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceBar2 : MonoBehaviour {

    

    public const int maxForce = 100;
    public int currentForce = 0;
    private bool m_isRunning = false;
    public RectTransform forceBar;
    public float m_timeElapsed = 0.0f;

    private bool reverse = false;
    private GameObject Player1;
    private Pin1 Player1Script;
    private Canvas CanvasObject; // Assign in inspector
 


    public void restart()
    {
        m_isRunning = !m_isRunning;
        CanvasObject.enabled = !CanvasObject.enabled;
    }

    public void SetForce(int amount)
    {
        currentForce += amount;
        forceBar.sizeDelta = new Vector2(currentForce, forceBar.sizeDelta.y);
       Player1Script.setForce(currentForce);
    }

    // Use this for initialization
    void Start () {
        CanvasObject = GetComponent<Canvas>();
        Player1 = GameObject.FindWithTag("Player1");
        Player1Script = Player1.GetComponent<Pin1>();
        forceBar.sizeDelta = new Vector2(currentForce, forceBar.sizeDelta.y);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_isRunning = !m_isRunning;
            CanvasObject.enabled = !CanvasObject.enabled;
        }
    }

    private void FixedUpdate()
    {
        if (!m_isRunning)
        {
            if (currentForce <= 0)
                reverse = false;
            if (currentForce >= 100)
                reverse = true;

            m_timeElapsed += Time.fixedDeltaTime;
            if (reverse == false && m_timeElapsed >= 0.01)
                SetForce(2);

            if (reverse == true && m_timeElapsed >= 0.01)
                SetForce(-2);

            if (m_timeElapsed >= 0.15)
                m_timeElapsed = 0.0f;
        }
    }
}
