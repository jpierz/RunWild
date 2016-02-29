﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    private bool grounded;

    private Rigidbody2D player;
    private Collider2D playerCollider;
    private Animator playerAnimator;
    public LayerMask ground;

	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

        //See if the player's collider is touching the ground layer
        grounded = Physics2D.IsTouchingLayers(playerCollider, ground);

        //Player speed
        player.velocity = new Vector2(moveSpeed, player.velocity.y);
        playerAnimator.SetFloat("Speed", player.velocity.x);
        playerAnimator.SetBool("Grounded", grounded);

        //Jump on space/left mouse
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) {
            //Only allow jumping if the player is on the ground
            if (grounded) {
                player.velocity = new Vector2(player.velocity.x, jumpForce);
            }
            
        }
	
	}
}