using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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

        
        PlayableDirector director = GetComponent<PlayableDirector>();
        director.Play();
    }

    public GameObject GetNextwayPoint() { return nextWayPoint; }
}
