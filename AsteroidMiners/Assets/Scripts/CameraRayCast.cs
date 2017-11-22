using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour {

    private GameObject stareTarget;

	// Use this for initialization
	void Start () {
		
	}

    void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(Camera.main.transform.position, 5f);
    }

    // Update is called once per frame
    void Update () {
        Vector3 rayOrigin = Camera.main.transform.position;
        Vector3 rayDirection = Camera.main.transform.forward;

        RaycastHit raycastHit = new RaycastHit();

        if(stareTarget != null) {
            Debug.DrawLine(rayOrigin, stareTarget.transform.position);
        }
        
        if ( Physics.SphereCast( rayOrigin, 5f, rayDirection, out raycastHit) && raycastHit.collider)
        {
            GameObject hitTarget = raycastHit.collider.gameObject;


            if (stareTarget == null || !hitTarget.Equals(stareTarget))
            {
                stareTarget = hitTarget;
                Debug.Log("Looking at " +stareTarget.name);


            }   
        }
	}
}
