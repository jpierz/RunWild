using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private PlayerController player;
    private Vector3 lastPlayerPosition;
    private float distanceToMove;

    // Use this for initialization
    void Start() {
        //Getting the player
        player = FindObjectOfType<PlayerController>();

        //Initial start position of the player
        lastPlayerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update() {
        //Calculating distance to move
        distanceToMove = player.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        //Updating last player position
        lastPlayerPosition = player.transform.position;
    }
}
