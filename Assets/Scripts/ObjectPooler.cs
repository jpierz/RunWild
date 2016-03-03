using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

    //For the platform and how many to initialize
    public GameObject pooledPlatform;
    public int amountObjects;

    //List for platforms
    private List<GameObject> platforms;

    // Use this for initialization
    void Start() {
        platforms = new List<GameObject>();

        //Add non-active objects to a list
        for (int i = 0; i < amountObjects; i++) {
            GameObject obj = (GameObject)Instantiate(pooledPlatform);
            obj.SetActive(false);
            platforms.Add(obj);
           
        }
	}

    //Getting a pooled platform
    public GameObject GetPooledPlatform() {
        //Searching for an inactive object
        for (int i = 0; i < platforms.Count; i++) {
            if (!platforms[i].activeInHierarchy) {
                //Found an inactive object, return it to be used
                return platforms[i];
            }
        }

        //Adding a pooled object, no inactive ones were found
        GameObject obj = (GameObject)Instantiate(pooledPlatform);
        obj.SetActive(false);
        platforms.Add(obj);
        return obj;
    }
}
