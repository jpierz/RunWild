﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    //Variables for controlling the player
    public float moveSpeed;
    public float jumpForce;
    private bool grounded;
    private int doubleJump;
    public float jumpTime;
    private float jumpTimeCounter;

    //For more details about the player
    private Rigidbody2D player;
    //private Collider2D playerCollider;
    private Animator playerAnimator;
    public LayerMask ground;

    //New variables for increasing speed
    public float speedUpValue;
    public float speedMilestone;
    private float speedMilestoneCounter;
    private int milestonesAchieved;

    //Redoing detection for the player to only detect ground from the bottom
    public Transform groundDetect;
    public float groundDetectRadius;

    //New variables for changing the sprites mid animation. A handler on the ReskinAnimation class to update the variable there
    //An array of sprite sheet names, and a counter to increment through that array
    public ReskinAnimation changeSkin;
    public string[] spriteSheetNames;
    private int skinCounter;

    //References of SceneManager to reload scene and ScoreManager to control the score
    private SceneManager SceneManager;
    public ScoreManager scoreManager;

    public ParticleSystem stars;

    // Use this for initialization
    void Start() {
        //Init for objects/components
        player = GetComponent<Rigidbody2D>();

        //playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();

        //Updating the jumpTimeCounter to actually be changed and leave jumpTime static
        jumpTimeCounter = jumpTime;

        //Setting the first milestone
        speedMilestoneCounter = speedMilestone;

        //Initializing the skinCounter
        skinCounter = 0;

        //Initializing the milestonesAchieved counter
        milestonesAchieved = 0;

        doubleJump = 0;

        stars.GetComponent<ParticleSystem>().Stop();

    }
	
	// Update is called once per frame
	void Update () {
        //See if the player's collider is touching the ground layer
        //grounded = Physics2D.IsTouchingLayers(playerCollider, ground);
        grounded = Physics2D.OverlapCircle(transform.position, groundDetectRadius, ground);

        //If player is past the milestone point, then speed him up and also increase the next milestone point by a factor of moveSpeed to keep
        //the milestones spaces out
        if (transform.position.x > speedMilestoneCounter) {
            moveSpeed *= speedUpValue;
            speedMilestoneCounter += speedMilestone;
            speedMilestone *= speedUpValue;
            milestonesAchieved++;

            //If the counter won't go out of array's bounds, the player has achieved 2 milestones, and the number of milestones passed is odd
            //just to extend the life of each sprite, otherwise they cycle through too fast
            if (skinCounter < spriteSheetNames.Length && milestonesAchieved > 2 && milestonesAchieved % 3 == 0) {
                //Update the spritesheet of the character by using the changeSkin handle to ReskinAnimation
                changeSkin.spriteSheetName = spriteSheetNames[skinCounter];
                skinCounter++;
                enableTrails();
            }         
        }
        //Player speed
        player.velocity = new Vector2(moveSpeed, player.velocity.y);
        
        //Setting speed and whether player is grounded for the animations
        playerAnimator.SetFloat("Speed", player.velocity.x);
        playerAnimator.SetBool("Grounded", grounded);

        //Jump on space/left mouse
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) {
            //Only allow jumping if the player is on the ground
            if (grounded) {
                player.velocity = new Vector2(player.velocity.x, jumpForce);
                doubleJump++;
            } else if (doubleJump < 1) {
                player.velocity = new Vector2(player.velocity.x, (float)(jumpForce * 1.5));
                doubleJump++;
            }
            
        }

        //Allowing the player to continue jumping for a little bit, adding a long jump effect
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
            if (jumpTimeCounter > 0) {
                player.velocity = new Vector2(player.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        //When the jump key is released, don't allow any more jumps (before you could jump mid-air)
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) {
            jumpTimeCounter = 0;
        }

        //Reset the jumpTimeCounter when grounded, allowing for a long jump
        if (grounded) {
            jumpTimeCounter = jumpTime;
            doubleJump = 0;
        }
	
	}

    //"Death" of the player
    void OnCollisionEnter2D(Collision2D other) {

        //If the collision is an object with the tag killbox, reset
        if (other.gameObject.tag == "killbox") {

            //Stop scoring
            scoreManager.setScoringFalse();

            //Save the current scores
            scoreManager.saveScore();

            //Reloading the level
            SceneManager.LoadScene("Runner");
        }
    }

    public void enableTrails() {
        stars.GetComponent<ParticleSystem>().Play();
        StartCoroutine("disableTrails");
    }

    private IEnumerator disableTrails() {
        yield return new WaitForSeconds(1);
        stars.GetComponent<ParticleSystem>().Stop();
    }
}
