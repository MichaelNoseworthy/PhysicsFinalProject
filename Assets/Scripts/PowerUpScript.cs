using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {


    public GameObject PowerUpPositionNew;
    public GameObject PowerUpPositionOld;

    float speed = 25;
    float resetPoint = 0;

    bool resetmyself = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (resetmyself == true)
        {

            float pointspeed = 0.7f;
            // The step size is equal to speed times frame time.
            resetPoint += pointspeed * Time.deltaTime;

            if (resetPoint >= 3)
            {
                resetPosition();
                resetPoint = 0;
            }
        }
	}

    public void resetPosition()
    {
        transform.position = PowerUpPositionOld.transform.position;
        resetmyself = false;
    }

    public void setPosition()
    {
        transform.position = PowerUpPositionNew.transform.position;
        resetmyself = true;
    }
}
