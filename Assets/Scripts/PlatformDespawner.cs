using UnityEngine;
using System.Collections;

public class PlatformDespawner : MonoBehaviour {

    public GameObject despawnPoint;

	// Use this for initialization
	void Start () {
        despawnPoint = GameObject.Find("DespawnPoint");
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.x < despawnPoint.transform.position.x) {
            gameObject.SetActive(false);
        }
	}
}
