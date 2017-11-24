using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterSpawn : SequenceTrigger {

    public GameObject fighterPrefab;  

    public void ExecuteTrigger ()
    {
        GameObject fighters = GameObject.Find("Fighters");
        GameObject spawn = GameObject.Find("Fighter/FighterSpawn");
        GameObject target = GameObject.Find("Fighter/FighterTarget");

        GameObject newFighter = Instantiate(fighterPrefab, fighters.transform);
        newFighter.transform.position = spawn.transform.position;
    } 
}
