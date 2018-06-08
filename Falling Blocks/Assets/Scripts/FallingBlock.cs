using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

    public Vector2 speedMinMax; // Variable min and max speed based on the difficulty % - editable in Inspector.
    float speed; // Variable for speed

    float visibleHeightThreshold; // Variable for the visible height

    private void Start() {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent()); // Linearly interpolates between min and max speed by the difficulty % - To increase the speed make it more diffcilut over time.

        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y; // How much is the visible height threshold
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.Self); // Making the blocks falling in -Y direction by their speed in self space (for the rotation to be in local space).

        if(transform.position.y < visibleHeightThreshold) { // Destory Falling Blocks after they go off screen
            Destroy(gameObject);

        }
	}
}
