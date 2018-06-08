using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

    float speed = 7f; // Initialising the speed of the falling blocs

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.Self); // Making the blocks falling in -Y direction by their speed in self space (for the rotation to be in local space).


	}
}
