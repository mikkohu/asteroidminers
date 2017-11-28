using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : MonoBehaviour {

    public static SequenceManager instance = null;

    private int collectedOre = 0;

    private bool collectingOre = false;

    private bool hangarOpen = false;

    private GameObject player;


	//Make SequenceManager a singleton
	void Awake () {
		if ( instance == null )
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
	}

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
        if(hangarOpen && !collectingOre && player.GetComponent<PlayerShipMove>().moveSpeed < 5.5f)
        {
            Mathf.Clamp(player.GetComponent<PlayerShipMove>().moveSpeed += 0.005f, 0f, 1.5f);
        }

        if(collectedOre >= 5 && collectingOre)
        {
            player.GetComponent<PlayerShipMove>().SetActiveWaypoint(GameObject.Find("hangar"));
            collectingOre = false;
        } 
    }

    public void setCollectingOre(bool b)
    {
        collectingOre = b;
    }

    public void setHangarOpen(bool b)
    {
        hangarOpen = b;
    }

    public void oreCollected()
    {
        collectedOre++;
    }

    public bool isNextToAsteroids()
    {
        return collectingOre;
    }
}
