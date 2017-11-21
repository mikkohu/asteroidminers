using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
public class HangarStartScript : MonoBehaviour {

    private PlayableDirector pd;
    private GameObject player;
	// Use this for initialization
	void Start () {
        pd = GetComponent<PlayableDirector>();
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
        if(pd.state == PlayState.Paused)
        {
            Debug.Log("Hangar opened");
            Mathf.Clamp(player.GetComponent<PlayerShipMove>().moveSpeed += 0.00001f, 0f, 0.05f);
        }	
	}
}
