using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour {
    //Variable for scroll speed and getting the renderer of the background
    public float scrollSpeed;
    private Renderer renderer1;

    void Start() {
        renderer1 = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        //Setting the offset and assigning that to a new Vector2, then updating the offset of the texture
        var offset = new Vector2(Time.time * scrollSpeed, 0f);
        renderer1.material.mainTextureOffset = offset;
            
	}
}
