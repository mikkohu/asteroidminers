using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour {

    private GameObject stareTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rayOrigin = Camera.main.transform.position;
        Vector3 rayDirection = Camera.main.transform.forward;

        RaycastHit raycastHit = new RaycastHit();

        if ( Physics.SphereCast( rayOrigin, 5f, rayDirection, out raycastHit))
        {

        }
	}
}
