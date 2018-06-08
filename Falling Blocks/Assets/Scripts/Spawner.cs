using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject fallingBlockPrefab; // Reference to the Falling Block prefab in Inspector
    public Vector2 secondsBetweenSpawnsMinMax; // Variable for seconds between spawns based on the difficulty % - editable in Inspector.
    float nextSpawnTime; // Spawn time after the the previous spawn time has finished

    public Vector2 spawnSizeMinMax; // Declaring variable for the min and max size the blocks can be - editable in Inspector.
    public float spawnAngleMax; // Declaring variable for the rotation of the blocks

    Vector2 screenHalfSizeWorldUnits; // Declaring the screen half size, we need this to know where we can spawn the blocks in

    // Use this for initialization
    void Start () {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize); // Getting the screen half size for X and Y. X by multipling the aspect ratio by the orthographicSize. Y by just pass the orthographicSize which is the camera half-size
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawnTime) { // If the current time in the game is greater than the next spawn time we're ready to spawn the next object
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent()); // Linearly interpolates between max and min spawn size by the difficulty % - To decrease the time between spawns make it more diffcilut over time.
            nextSpawnTime = Time.time + secondsBetweenSpawns; // Once we pass the spawn time, the spawn time gets increased by the amount of time we want between the spawns 

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y); // Spawn size is random between the min and manx values given in the Inspector.
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize); // Spawn position can be anywhere on the X axis betwwen - and +. For the Y axis we want to spawn the blocks from the top of the screen +  the hight of the object so that the object spawns above the screen.
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle)); // Instantiating the Falling Block prefab given the position and creating reference to the object (using cast), because we want to be able to scale the object. To get the rotation on the Z axis (because 2D) we need to mulitply Vector3.forward by the spawnAngle and we conver it to Quaternion to be able to pass into the Instantiate method.
            newBlock.transform.localScale = Vector2.one * spawnSize; // Blocks will have a scale of spawnsize on both the X and Y axis.
        }
	}
}
