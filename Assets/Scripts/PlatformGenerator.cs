using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    //The ground to be spawned
    public GameObject groundPlatform;

    //The point where the spawn location is
    public Transform spawnPoint;

    //Width of the platform, to know how far ahead to add platform
    private float platformWidth;

    //Randomizing a little bit of distance
    public int minGapDistance;
    public int maxGapDistance;
    private int gapRandomDistance;

    //A reference to the objPooler class
    public ObjectPooler objPooler;
	// Use this for initializationd
	void Start () {
        //Getting the platform width
        platformWidth = groundPlatform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
        //If the PlatformGenerator is behind the spawnPoint
	    if (transform.position.x < spawnPoint.position.x) {
            //Calculating random distance
            gapRandomDistance = Random.Range(minGapDistance, maxGapDistance);

            //Updating the location of the PlatformGenerator and creating the spawn point for the new platform
            transform.position = new Vector3(transform.position.x + platformWidth + gapRandomDistance, transform.position.y, transform.position.x);

            //Getting a new object and updating its position. Setting rotation to the PlatformGenerator's rotation
            //So it wont flip out
            groundPlatform = objPooler.GetPooledObject();
            groundPlatform.transform.position = transform.position;
            groundPlatform.transform.rotation = transform.rotation;
            groundPlatform.SetActive(true);
        }
	}
}
