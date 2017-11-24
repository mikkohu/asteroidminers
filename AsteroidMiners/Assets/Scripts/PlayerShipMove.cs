using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMove : MonoBehaviour {

    public delegate void collide(Collider other, GameObject go);

    private GameObject[] waypoints;

    private GameObject activeWaypoint;
    private GameObject previousWaypoint;

    public GameObject probePrefab;

    private Transform forwardHelper;
    //private Vector3 direction;

    public bool nextToAsteroids = false;

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
                if(otherObject.tag == "Player" &&
                    go == activeWaypoint)
                {
                    //Check whether there are more waypoints in the list
                    if (script.GetNextwayPoint() != null)
                    {
                        previousWaypoint = gameObject;
                        activeWaypoint = script.GetNextwayPoint();
                        if (!activeWaypoint.GetComponent<Waypoint>().GetNextwayPoint())
                        {
                            rotateSpeed = 0f;
                            nextToAsteroids = true;
                        }
                    }
                }
            };

            script.SetCollision(c);
        }
        
	}

    // Spawn a probe that flies towards given gameobject
    public void SpawnProbe (GameObject asteroid)
    {
        GameObject newProbe = Instantiate(probePrefab, transform.position + Vector3.down, transform.rotation);
        newProbe.GetComponent<ProbeScript>().SetTarget(asteroid);
        
    }

	
	// Update is called once per frame
	void Update () {

        //Slow down the ship when approaching the final waypoint.
        if (!activeWaypoint.GetComponent<Waypoint>().GetNextwayPoint())
        {
            float waypointDistance = Vector3.Distance(previousWaypoint.transform.position, activeWaypoint.transform.position);
            float shipDistance = Vector3.Distance(transform.position, activeWaypoint.transform.position);
            moveSpeed = moveSpeed * (shipDistance / waypointDistance); 
        }
        
        //Apply forward movement to the object
        Vector3 direction = forwardHelper.position+transform.position;
        transform.position = Vector3.MoveTowards(transform.position, forwardHelper.position, Time.deltaTime * moveSpeed);

        //Rotate towards the next waypoint
        Vector3 rotateDir = activeWaypoint.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, rotateDir,
            rotateSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
	}
}
