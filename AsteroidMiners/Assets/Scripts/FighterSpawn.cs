using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterSpawn : SequenceTrigger {

    public GameObject fighterPrefab;  

    public override void ExecuteTrigger ()
    {
        if(fighterPrefab != null)
        {
            GameObject fighters = GameObject.Find("Fighters");
            GameObject spawn = GameObject.Find("Fighters/FighterSpawn");
            GameObject target = GameObject.Find("Fighters/FighterTarget");

            GameObject newFighter = Instantiate(fighterPrefab, fighters.transform);
            newFighter.transform.position = spawn.transform.position;
            Quaternion rot = newFighter.transform.rotation;
            //rot.SetEulerAngles(rot.x, rot.y + 90, rot.z);
            newFighter.transform.rotation = Quaternion.Euler(rot.x, rot.y + 90, rot.z);
            newFighter.GetComponent<SlowMove>().moveSpeed = 200f;

        }
        
    } 
}
