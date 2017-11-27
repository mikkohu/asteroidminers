using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeScript : MonoBehaviour {

    public float moveSpeed;
    public float turnSpeed;

    private GameObject target;
    private Transform forwardHelper;

    public void SetTarget(GameObject go)
    {
        target = go;
    }
    
	// Use this for initialization
	void Start () {
        forwardHelper = transform.Find("ForwardHelper");
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "asteroid")
        {
            Destroy(gameObject);
            SequenceManager.instance.oreCollected();
        }
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = forwardHelper.position + transform.position;
        transform.position = Vector3.MoveTowards(transform.position, forwardHelper.position, Time.deltaTime * moveSpeed);

        Vector3 rotateDir = target.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, rotateDir,
            turnSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);

    }
}
