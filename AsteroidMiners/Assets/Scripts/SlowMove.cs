using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMove : MonoBehaviour {

    private Transform forwardHelper;
    public float moveSpeed = 0.01f;
	// Use this for initialization
	void Start () {
        forwardHelper = transform.Find("ForwardHelper");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = forwardHelper.position + transform.position;
        transform.position = Vector3.MoveTowards(transform.position, forwardHelper.position, Time.deltaTime * moveSpeed);

    }
}
