using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollisionRelay : MonoBehaviour {

    public PlaneController planeController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other) {
        planeController.Collision();
    }

}
