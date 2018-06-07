using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 7f;
    float screenHalfWidthInWorldUnits;

	// Use this for initialization
	void Start () {

        float halfPlayerWidth = transform.localScale.x / 2; // Getting the half width of the player which we need to add to screenHalfWidthInWorldUnits. This will prevent screen wrapping when the center on the player reaches the screenHalfWidthInWorldUnits
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth; // Aspect ratio (screen width / screen height) * orthographicSize (screen height (world units) / 2) = screen width (world units) / 2
        //screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth; // Same as above but this time used no to scrren wrap but to screen collision system.
    }
	
	// Update is called once per frame
	void Update () {

        float inputX = Input.GetAxisRaw("Horizontal"); // Input only works for the X axis
        float velocity = inputX * speed; // Velocity -> number of meters traveled in a given direction per second 
        transform.Translate(Vector2.right * velocity * Time.deltaTime); // Moving the player by the X axis

        if(transform.position.x < -screenHalfWidthInWorldUnits) { // Screen wrapping from left to right. If the player has gone off the left edge of the screen, move the player to the right edge of the screen
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

        //if (transform.position.x < screenHalfWidthInWorldUnits) { // Same as above but this time used no to scrren wrap but to screen collision system.
        //    transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        //}

        if (transform.position.x > screenHalfWidthInWorldUnits) { // Screen wrapping from right to left. If the player has gone off the right edge of the screen, move the player to the left edge of the screen
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }

        //if (transform.position.x > screenHalfWidthInWorldUnits) { // Same as above but this time used no to scrren wrap but to screen collision system.
        //    transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        //}
    }
}
