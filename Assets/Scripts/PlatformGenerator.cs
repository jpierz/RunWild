using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    //The ground to be spawned
    public GameObject groundPlatform;
    public GameObject theCoin;

    //The point where the spawn location is
    public Transform spawnPoint;

    //Width of the platform, to know how far ahead to add platform
    private float[] platformWidths;

    //Randomizing a little bit of distance
    public int minGapDistance;
    public int maxGapDistance;
    private int gapRandomDistance;

    //An array for each of the platform lengths of the objectPooler class
    public ObjectPooler[] objPooler;

    //An array for the coins
    public ObjectPooler[] objPoolerCoins;


    //Using this as the random selector
    private int platformSelector;

    //New variables for the random height of platforms
    public Transform maxHeightPoint;
    public float heightVariation;
    private float minHeight;
    private float maxHeight;
    private float heightChange;
    
	// Use this for initializationd
	void Start () {
        //Setting up the array of platformWidths
        platformWidths = new float[objPooler.Length];
        //Adding all the lengths of the platforms added
        for (int i = 0; i < objPooler.Length; i++) {
            platformWidths[i] = objPooler[i].pooledPlatform.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.transform.position.y;
        
	}
	
	// Update is called once per frame
	void Update () {
        //If the PlatformGenerator is behind the spawnPoint
	    if (transform.position.x < spawnPoint.position.x) {
            //Getting a random int for selecting
            platformSelector = Random.Range(0, objPooler.Length);
            //Calculating random distance
            gapRandomDistance = Random.Range(minGapDistance, maxGapDistance);

            //Creating a random height and adding it to the current platform's height, it could go lower or higher
            heightChange = transform.position.y + Random.Range(heightVariation, -heightVariation);

            //Checking to make sure the new random height is within the bounds set
            if (heightChange > maxHeight) {
                heightChange = maxHeight;
            } else if (heightChange < minHeight) {
                heightChange = minHeight;
            }
            //Updating the location of the PlatformGenerator and creating the spawn point for the new platform.
            //Without the (platformWidths[platformSelector] / 2), the point was always in the middle of the platform
            //So sometimes platforms would be spawned from the middle of a platform, making a huge long connected one
            //With this bit, the point is always at the end of the platform so new spawns will go there + random distance
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + gapRandomDistance, heightChange, transform.position.z);

            //Getting a random platform and getting a free instance, updating its position, and making it active
            groundPlatform = objPooler[platformSelector].GetPooledPlatform();
            groundPlatform.transform.position = transform.position;
            groundPlatform.transform.rotation = transform.rotation;
            groundPlatform.SetActive(true);

            //Making the coin spawning a bit more rare by adding RNG to it
            if ((Random.Range(0, 5) == 3)) {
                //Same thing with selecting a platform, using object pooling for the coins and making it active
                theCoin = objPoolerCoins[platformSelector].GetPooledCoin();

                //This position is actually the point a bit off the actual platform itself which works perfect as players can grab the coins as they jump and not waste
                //jumps in the middle of the platform and throwing their next jump timer off causing them to die
                theCoin.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
                theCoin.transform.rotation = transform.rotation;
                theCoin.SetActive(true);
            }


            //Adds a little bit of distance for the next calculation to space the platforms out a bit from the edge of the previous platform
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.x);
        }
	}
}
