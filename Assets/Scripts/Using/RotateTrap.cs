using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrap : MonoBehaviour {

    public float rotationspeedx;
    public float rotationspeedy;
    public float rotationspeedz;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        this.transform.Rotate(new Vector3(rotationspeedx, rotationspeedy, rotationspeedz));
		
	}
}
