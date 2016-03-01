using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

    public GameObject pooledObject;
    public int amountObjects;

    private List<GameObject> objects;

    // Use this for initialization
    void Start() {
        objects = new List<GameObject>();

        //Add non-active objects to a list
        for (int i = 0; i < amountObjects; i++) {
            GameObject obj = (GameObject) Instantiate(pooledObject);
            obj.SetActive(false);
            objects.Add(obj);
        }
	}

    public GameObject GetPooledObject() {

        //Searching for an inactive object
        for (int i = 0; i < objects.Count; i++) {
            if (!objects[i].activeInHierarchy) {
                return objects[i];
            }
        }

        //Adding a pooled object, no inactive ones were found
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        objects.Add(obj);
        return obj;

    }
	
    
}
