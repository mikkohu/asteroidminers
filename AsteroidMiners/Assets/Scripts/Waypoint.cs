﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Waypoint : MonoBehaviour {

    private PlayerShipMove.collide collisionFunc;

    public GameObject nextWayPoint;

    public SequenceTrigger sequenceTrigger;

    public void SetCollision(PlayerShipMove.collide col)
    {
        collisionFunc = col;
    }

    void OnDrawGizmos()
    {
        if(nextWayPoint != null)
        {
            Gizmos.DrawLine(transform.position, nextWayPoint.transform.position);
        }        
    }
        
    void OnTriggerEnter(Collider other)
    {
        collisionFunc(other, gameObject);
        if(sequenceTrigger != null)
        {
            sequenceTrigger.ExecuteTrigger();
        }        
    }

    public GameObject GetNextwayPoint() { return nextWayPoint; }
}
