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
        Debug.Log(transform.Find("ForwardHelper"));
        forwardHelper = transform.Find("ForwardHelper");

        //Find waypoints in the scene
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");

        Debug.Log(waypoints.Length+" waypoints found");
        activeWaypoint = GameObject.Find("waypoint");

        foreach (GameObject wp in waypoints)
        {
            Waypoint script = wp.GetComponent<Waypoint>();

            //Create a delegate for the OnTriggerEnter of waypoints
            collide c = (other, go) =>
            {
                Debug.Log(go.name);
                GameObject otherObject = other.gameObject;
                Debug.Log(otherObject.tag);
                Debug.Log(go == activeWaypoint);

                if(otherObject.tag == "Player" &&
                    go == activeWaypoint)
                {
                    int i = Array.IndexOf(waypoints, activeWaypoint);
                    //Check whether there are more waypoints in the list
                    if (script.GetNextwayPoint() != null)
                    {                        
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
        Vector3 direction = forwardHelper.transform.position+transform.position;
        transform.Translate(direction * -moveSpeed * Time.deltaTime);

        Vector3 rotateDir = activeWaypoint.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, rotateDir,
            rotateSpeed * Time.deltaTime, 0f);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
	}
}
