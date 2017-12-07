using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

  public bool alive = true;
	public GameObject spawnPoint;
  public GameObject lightSpawn;
	[SerializeField]
	private GameObject[] enemies;
	[SerializeField]
	private int maxEnemiesOnScreen;
	[SerializeField]
	private int totalEnemies;
	[SerializeField]
	private int enemiesPerSpawn;
	[SerializeField]
	private int spawnDelay;
  [SerializeField]
  private GameObject light;
	private int enemiesOnScreen = 0;
	public int score = 0;
  [SerializeField]
  private GameObject dialogbox;
  int randomAlien = 0;
  int spawnedAlien = 5;

	// Use this for awake time
	void Awake() {
	}
	public void Death(){
		alive = false;
	}
	public bool getLife(){
		return alive;
	}
  public int getScore(){
    return score;
  }
	// Spawns new enemy on the screen
	void spawnEnemy() {
		if (enemiesPerSpawn > 0 && enemiesOnScreen < totalEnemies) {
			for (int i = 0; i < enemiesPerSpawn; i++) {
				if (enemiesOnScreen < maxEnemiesOnScreen) {
					GameObject newEnemy = Instantiate(enemies[0]) as GameObject;
					newEnemy.transform.position = spawnPoint.transform.position;
					enemiesOnScreen++;
				}
			}
		}
	}

	IEnumerator spawn(){
		if ( enemiesPerSpawn > 0 && enemiesOnScreen < totalEnemies) {
			for (int i = 0; i < enemiesPerSpawn; i++) {
        do {
            randomAlien = Random.Range (0, 4);
        } while(randomAlien == spawnedAlien);
				if (enemiesOnScreen < maxEnemiesOnScreen) {
					Debug.Log("Generating Enemy!");
          if (spawnedAlien != randomAlien) {
            GameObject newEnemy = Instantiate(enemies[randomAlien]) as GameObject;
  					newEnemy.transform.position = spawnPoint.transform.position;
          }
          spawnedAlien = randomAlien;
					enemiesOnScreen++;
          totalEnemies++;
				}
			}
			yield return new WaitForSeconds(Random.Range(0.0f,8f));
			StartCoroutine(spawn());
		}
	}

	// Destroys an enemy
 	public void removeEnemyFromScreen(){
		if (enemiesOnScreen > 0) {
			enemiesOnScreen--;
		}
		score++;
	}

	// Use this for initialization
	void Start () {
    alive = true;

    GameObject newLight = Instantiate(light) as GameObject;
    newLight.transform.position = lightSpawn.transform.position;
	}

	// Update is called once per frame
	void Update () {
 			 if (Input.GetKeyDown(KeyCode.R))
 			 {
           DestroyImmediate(Camera.main.gameObject);
           Application.LoadLevel(Application.loadedLevel);
 			}
      else if (Input.GetKeyDown(KeyCode.M))
      {
         SceneManager.LoadScene(0);
     }
     if (alive) {
       StartCoroutine(spawn());
     }
	}
}
