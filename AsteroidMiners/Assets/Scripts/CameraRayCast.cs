using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour {

    private GameObject stareTarget;

    public float targetChangeTimer;
    //Private float to store the default value for targetChangeTimer
    private float changeTime;

	// Use this for initialization
	void Start ()
    {
        changeTime = targetChangeTimer;
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
            targetChangeTimer -= Time.deltaTime;
            if( targetChangeTimer <= 0)
            {
                if(stareTarget.tag == "asteroid")
                {
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    player.GetComponent<PlayerShipMove>().SpawnProbe(stareTarget);
                    targetChangeTimer = changeTime; //Reset timer
                }
            }
        }
        
        if ( Physics.SphereCast( rayOrigin, 5f, rayDirection, out raycastHit) && raycastHit.collider)
        {
            GameObject hitTarget = raycastHit.collider.gameObject;
            
            if (stareTarget == null || !hitTarget.Equals(stareTarget))
            {
                stareTarget = hitTarget;
                //Reset the timer
                targetChangeTimer = changeTime;
                Debug.Log("Looking at " + stareTarget.name);
            }
        }
	}
}
