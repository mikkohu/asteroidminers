using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotate : MonoBehaviour {

    private float rotX;
    private float rotY;
    private float rotZ;

	// Use this for initialization
	void Start () {
        transform.rotation = Random.rotation;
        rotX = Random.Range(0, 0.5f);
        rotY = Random.Range(0, 0.5f); 
        rotZ = Random.Range(0, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(rotX, rotY, rotZ), Space.Self);
        //Debug.Log(transform.rotation);
	}
}
