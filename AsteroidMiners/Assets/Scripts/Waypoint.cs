using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    private PlayerShipMove.collide collisionFunc;

    public GameObject nextWayPoint;

    public void SetCollision(PlayerShipMove.collide col)
    {
        collisionFunc = col;
    }

    void OnTriggerEnter(Collider other)
    {
        collisionFunc(other, gameObject);
    }

    public GameObject GetNextwayPoint() { return nextWayPoint; }
}
