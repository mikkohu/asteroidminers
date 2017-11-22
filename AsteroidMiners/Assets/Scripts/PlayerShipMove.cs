using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMove : MonoBehaviour {

    public delegate void collide(Collider other, GameObject go);

    private GameObject[] waypoints;

    private GameObject activeWaypoint;

    private Transform forwardHelper;
    //private Vector3 direction;

    public float moveSpeed;
    public float rotateSpeed;

	// Use this for initialization
	void Start () {
        forwardHelper = transform.Find("ForwardHelperPlayer");

        //Find waypoints in the scene
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");

        Debug.Log(waypoints.Length+" waypoints found");
        activeWaypoint = GameObject.Find("waypoint_00");

        foreach (GameObject wp in waypoints)
        {
            Waypoint script = wp.GetComponent<Waypoint>();

            //Create a delegate for the OnTriggerEnter of waypoints
            collide c = (other, go) =>
            {
                GameObject otherObject = other.gameObject;
                Debug.Log(otherObject.tag == "Player");
                Debug.Log(go == activeWaypoint);
                if(otherObject.tag == "Player" &&
                    go == activeWaypoint)
                {
                    //Check whether there are more waypoints in the list
                    Debug.Log(script.GetNextwayPoint());
                    if (script.GetNextwayPoint() != null)
                    {
                        Debug.Log("New target gained!");
                        activeWaypoint = script.GetNextwayPoint();
                    }
                }
            };

            script.SetCollision(c);
        }
        
	}

	
	// Update is called once per frame
	void Update () {
        //Apply forward movement to the object
        Vector3 direction = forwardHelper.position+transform.position;
        Debug.DrawLine(transform.position, forwardHelper.position);
        //transform.Translate(direction * -moveSpeed * Time.deltaTime, Space.World);
        transform.position = Vector3.MoveTowards(transform.position, forwardHelper.position, Time.deltaTime * moveSpeed);

        Vector3 rotateDir = activeWaypoint.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, rotateDir,
            rotateSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
	}
}
