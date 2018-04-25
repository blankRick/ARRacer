using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public List<GameObject> blocks;

    public ObstacleSO obso1;
    private Obstacle obs1;

	// Use this for initialization
	void Start () {
        obs1 = obso1.obstacle;
        //obs1 = Helpers.MirrorVertical(obs1);
        //obs1 = Helpers.Negative(obs1);
        ApplyObs();
        Debug.Log(Helpers.GetRating(obs1));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ApplyObs() {
        for(int i = 0; i < blocks.Count; i++) {
            blocks[i].SetActive(obs1.list[i]);
        }
    }

}
