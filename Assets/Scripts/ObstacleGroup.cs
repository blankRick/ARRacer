using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGroup : MonoBehaviour {

    public float speed;
    public List<GameObject> blocks;

    public void Update() {
        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
    }

    public void Init(List<bool> list, float initSpeed) {
        for (int i = 0; i < blocks.Count; i++) {
            blocks[i].SetActive(list[i]);
        }
        speed = initSpeed;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Score") {
            GameManager.instance.Scored();
        } else {
            gameObject.SetActive(false);
        }
    }

}
