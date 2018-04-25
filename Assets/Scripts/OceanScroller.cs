using UnityEngine;
using System.Collections;

public class OceanScroller : MonoBehaviour {

    public float speedX, speedY;
    Renderer myRenderer;

	// Use this for initialization
	void Start () {
        myRenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        myRenderer.material.mainTextureOffset = new Vector2(myRenderer.material.mainTextureOffset.x + speedX * Time.deltaTime, myRenderer.material.mainTextureOffset.y + speedY * Time.deltaTime);
	}
}
