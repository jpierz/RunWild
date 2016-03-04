using UnityEngine;
using System.Collections;
using System;

public class ReskinAnimation : MonoBehaviour {

    //The sprite sheet name to be used to change the sprite during animation
    public string spriteSheetName;


	//Using LateUpdate here because LateUpdate handles animation and is called after normal Update
	void LateUpdate () {
        //Loading all sprites from the resource/characters folder, also loading all the sub sprites in each sprite sheet
        var subSprites = Resources.LoadAll<Sprite>("Characters/" + spriteSheetName);

        //This loops through all subsprite pieces
        foreach (var renderer in GetComponentsInChildren<SpriteRenderer>()) {
            //Gets the sprie name
            string spriteName = renderer.sprite.name;
            //Finds the same name from the subsprites
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);

            //If there is one found, swap it out
            if (newSprite) {
                renderer.sprite = newSprite;
            }
        }
	
	}
}
