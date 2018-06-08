using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty { // This class file is not attached to any object in the game - It is called by other classes.

    static float secondsToMaxDifficulty = 60; // After 60 seconds max difficluty will be reached

    public static float GetDifficultyPercent() { // Returuns the current difficluty
        //return 1; // Returns the max difficulty instantly
        return Mathf.Clamp01(Time.time / secondsToMaxDifficulty); // Current time / secondsToMaxDifficulty restricted between 0 and 1
    }

}
