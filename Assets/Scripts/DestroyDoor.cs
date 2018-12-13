using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoor : MonoBehaviour {


    public bool destroyme = false;


    public void SelfDestruct()
    {
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (destroyme == true)
            {
            SelfDestruct();
        }
	}
}
