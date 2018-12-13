using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceBar : MonoBehaviour {


    public const int maxForce = 400;
    public int currentForce = 300;
    private bool m_isRunning = false;
    public RectTransform forceBar;
    public float m_timeElapsed = 0.0f;

    private bool reverse = false;
    private Canvas CanvasObject; // Assign in inspector
    public bool Pad1Status = false;
    public bool Pad2Status = false;
    public bool Pad3Status = false;
    public bool Pad4Status = false;

    //private Pin1 SetPin1;
    // private Pin2 SetPin2;
    public Text ForceText;
    public Text PinAmount;
    public Canvas WinText;
    public Canvas ButtonsBar;

    public bool GamePaused = false;


    public void SetForce(int amount)
    {

        ForceText.text = amount.ToString();

        if (Pad1Status == true && amount > 300)
            amount = amount - 300;

        if (Pad2Status == true && amount > GameObject.FindWithTag("Pad2").GetComponent<SittingPad1>().minForce)
            amount = amount - GameObject.FindWithTag("Pad2").GetComponent<SittingPad1>().minForce;

        if (Pad3Status == true && amount > GameObject.FindWithTag("Pad3").GetComponent<SittingPad1>().minForce)
            amount = amount - GameObject.FindWithTag("Pad3").GetComponent<SittingPad1>().minForce;

        if (Pad4Status == true && amount > GameObject.FindWithTag("Pad4").GetComponent<SittingPad1>().minForce)
            amount = amount - GameObject.FindWithTag("Pad4").GetComponent<SittingPad1>().minForce;

        //if (Pad2Status == true && amount > 300)
        //amount = amount - 300;

        currentForce = amount;

        forceBar.sizeDelta = new Vector2(currentForce, forceBar.sizeDelta.y);
        //Player1Script.setForce(currentForce);
    }

    public void WinGame()
    {
        WinText.enabled = true;
        ButtonsBar.enabled = true;
        CanvasObject.enabled = CanvasObject.enabled = false;
    }

    // Use this for initialization
    void Start () {
        CanvasObject = GetComponent<Canvas>();
        forceBar.sizeDelta = new Vector2(currentForce, forceBar.sizeDelta.y);
        /*
        Pad1Status = GameObject.FindWithTag("Pad1").GetComponent<SittingPad1>().GetStatus();
        Pad2Status = GameObject.FindWithTag("Pad2").GetComponent<SittingPad1>().GetStatus();
        Pad3Status = GameObject.FindWithTag("Pad3").GetComponent<SittingPad1>().GetStatus();
        Pad4Status = GameObject.FindWithTag("Pad4").GetComponent<SittingPad1>().GetStatus();
        */
        WinText.enabled = false;
        ButtonsBar.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        /*
        Pad1Status = GameObject.FindWithTag("Pad1").GetComponent<SittingPad1>().GetStatus();
        Pad2Status = GameObject.FindWithTag("Pad2").GetComponent<SittingPad1>().GetStatus();
        Pad3Status = GameObject.FindWithTag("Pad3").GetComponent<SittingPad1>().GetStatus();
        Pad4Status = GameObject.FindWithTag("Pad4").GetComponent<SittingPad1>().GetStatus();
        */
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ButtonsBar.enabled = !ButtonsBar.enabled;
            GamePaused = !GamePaused;
        }

        if (GamePaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        

    }

    private void FixedUpdate()
    {
        if (Pad1Status == true || Pad2Status == true || Pad3Status == true || Pad4Status == true)
        {
            //SetForce();
            CanvasObject.enabled = CanvasObject.enabled = true;
            
        }
        else CanvasObject.enabled = CanvasObject.enabled = false;
        
    }
}
