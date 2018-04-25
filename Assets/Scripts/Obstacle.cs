using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]    
public class Obstacle {

    public List<bool> list;
    public int difficultyRating;

    public Obstacle() {
        list = new List<bool>(9);
        difficultyRating = 1;
    }

    public Obstacle(List<bool> initList, int initDifficultyRating) {
        list = new List<bool>(initList);
        difficultyRating = initDifficultyRating;
    }

    public Obstacle(Obstacle input) {
        list = new List<bool>(input.list);
        difficultyRating = input.difficultyRating;
    }
}
