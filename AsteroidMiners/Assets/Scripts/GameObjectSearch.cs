using System;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSearch
{
    public static GameObject searchWithTag(GameObject[] objects, string tag)
    {
        foreach (GameObject gameObject in objects ) {
            if(gameObject.tag == tag)
            {
                return gameObject;
            }
        }
        //Return null if no gameObject with the give tag is found
        //in the given array
        return null;
    }
}