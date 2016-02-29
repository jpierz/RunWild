using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    //Instance of player class
    private PlayerController player;
    private float distanceToMove;
    private Vector3 lastPlayerPosition;
	// Use this for initialization
	void Start () {
        //Getting the player object through an instance of the class
        player = FindObjectOfType<PlayerController>();
        //Initially setting the lastPlayerPosition
        lastPlayerPosition = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        //Calculating distance to move
        distanceToMove = player.transform.position.x - lastPlayerPosition.x;

        //Moving the camera, only moving it on the x axis
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        //Updating last player position
        lastPlayerPosition = player.transform.position;


	
	}
}
