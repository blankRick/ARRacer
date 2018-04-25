using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject prefab;
    public Vector3 startingPosition;
    public float speed;
    public List<ObstacleSO> obstacles;
    private List<GameObject> pool = new List<GameObject>();
    public float intervalTime;
    public float spawnChance;
    public float negativeChance;
    public float mirrorHorizontalChance;
    public float mirrorVerticalChange;
    public static int score = 0;
    public Text scoreText;
    public GameObject menuPanel;
    public GameObject startingPanel;

    public static GameManager instance;

    private void Awake() {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Confined;
	}

    public void StartGame() {
        Invoke("StartRace", 3);
        menuPanel.SetActive(false);
        startingPanel.SetActive(true);
    }

    public void StartRace() {
        startingPanel.SetActive(false);
        scoreText.gameObject.SetActive(true);
        Invoke("GenerateNewObstacleGroup", intervalTime);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X)) {
            GenerateNewObstacleGroup();
        }
	}

    private void GenerateNewObstacleGroup() {
        if (HelperFunctions.ChanceChecker(spawnChance)) {

            GameObject newObs = GetGameObjectFromPool(prefab, pool);
            ObstacleGroup newObsGroup = newObs.GetComponent<ObstacleGroup>();
            newObs.transform.position = startingPosition;
            newObsGroup.Init(RandomObs(), speed);
        }
        Invoke("GenerateNewObstacleGroup", intervalTime);
    }

    private List<bool> RandomObs() {
        int randObsNo = Random.Range(0, obstacles.Count);
        Obstacle obs = obstacles[randObsNo].obstacle;

        int randomRotation = Random.Range(0, 4);

        for(int i = 0; i < randomRotation; i++) {
            obs = Helpers.Rotate90(obs);
        }

        if (HelperFunctions.ChanceChecker(negativeChance)) {
            obs = Helpers.Negative(obs);
        }

        if (HelperFunctions.ChanceChecker(mirrorHorizontalChance)) {
            obs = Helpers.MirrorHorizontal(obs);
        }

        if (HelperFunctions.ChanceChecker(mirrorVerticalChange)) {
            obs = Helpers.MirrorVertical(obs);
        }

        return obs.list;
    }



    private GameObject GetGameObjectFromPool(GameObject prefab, List<GameObject> pool) {
        GameObject goFromPool;
        if (pool.Count > 0) {
            goFromPool = pool.Find(X => X.activeInHierarchy == false);
            if (goFromPool == null) {
                goFromPool = GameObject.Instantiate(prefab);
                pool.Add(goFromPool);
                goFromPool.transform.parent = this.transform;
            } else {
                goFromPool.SetActive(true);
            }
        } else {
            goFromPool = GameObject.Instantiate(prefab);
            pool.Add(goFromPool);
            goFromPool.transform.parent = this.transform;
        }
        return goFromPool;
    }

    public void Scored() {
        score++;
        scoreText.text = score.ToString();
    }

    public void Collision() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

}
