using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

    //For the platform and how many to initialize
    public GameObject pooledPlatform;
    public int amountObjects;

    //For the coins
    public GameObject pooledCoin;
    public int amountCoins;

    //List for platforms
    private List<GameObject> platforms;
    private List<GameObject> coins;

    // Use this for initialization
    void Start() {
        platforms = new List<GameObject>();
        coins = new List<GameObject>();

        //Add non-active objects to a list
        for (int i = 0; i < amountObjects; i++) {
            GameObject obj = (GameObject)Instantiate(pooledPlatform);
            obj.SetActive(false);
            platforms.Add(obj);
           
        }

        //Adding an initial amount of coins
        for (int i = 0; i < amountCoins; i++) {
            GameObject obj = (GameObject)Instantiate(pooledCoin);
            obj.SetActive(false);
            coins.Add(obj);
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

    //Getting a pooled coin
    public GameObject GetPooledCoin() {
        //Searching for an inactive coin, if found return it
        for (int i = 0; i < coins.Count; i++) {
            if (!coins[i].activeInHierarchy) {
                return coins[i];
            }
        }

        //No inactive objects were found, create one and return it
        GameObject obj = (GameObject)Instantiate(pooledCoin);
        obj.SetActive(false);
        platforms.Add(obj);
        return obj;
    }
}
