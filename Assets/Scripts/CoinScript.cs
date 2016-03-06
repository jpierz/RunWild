using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
    //A score variable
    public int score;

    //Handle to the scoreManager script
    private ScoreManager scoreManager;

    public GameObject stars;

    private PlayerController player;
    private Vector3 starsSpawnPoint;
	// Use this for initialization
	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    //If the player collides with a coin, set it active to false and add the score of the coin
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            scoreManager.addScore(score);
            player.enableTrails();
            this.gameObject.SetActive(false);
        }
    }
}
