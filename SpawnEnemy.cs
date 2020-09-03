
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2;
    public int maxEnemies = 20;
}

public class SpawnEnemy : MonoBehaviour
{

    public GameObject[] waypoints;
    public GameObject testEnemyPrefab;

    public Wave[] waves;
    public int timeBetweenWaves = 7;

    private GameManagerBehavior gameManager;

    private float lastSpawnTime;
    private int enemiesSpawned = 0;

    Scene scene;
    void Start()
    {
        lastSpawnTime = Time.time;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        int currentWave = gameManager.Wave;
        if (currentWave < waves.Length)
        {
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) || timeInterval > spawnInterval) && enemiesSpawned < waves[currentWave].maxEnemies)
            {
                lastSpawnTime = Time.time;
                GameObject newEnemy = (GameObject)Instantiate(waves[currentWave].enemyPrefab);
                newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
                enemiesSpawned++;
            }
            if (enemiesSpawned == waves[currentWave].maxEnemies && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                gameManager.Wave++;
                gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.2f);
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
        }
        else
        {
            gameManager.gameOver = true;
            GameObject gameOverText = GameObject.FindGameObjectWithTag("GameWon");
            //Achievements
            if(scene.name == "Map1")
            {
                if (BulletBehavior.MoneyFactor == 1)
                {
                    ChooseMap.m1 = 2;
                }
                if (BulletBehavior.MoneyFactor == 2)
                {
                    ChooseMap.m1 = 1;
                }
            }
            if (scene.name == "Map2")
            {
                if (BulletBehavior.MoneyFactor == 1)
                {
                    ChooseMap.m2 = 2;
                }
                if (BulletBehavior.MoneyFactor == 2)
                {
                    ChooseMap.m2 = 1;
                }
            }
            if (scene.name == "Map2")
            {
                if (BulletBehavior.MoneyFactor == 1)
                {
                    ChooseMap.m3 = 2;
                }
                if (BulletBehavior.MoneyFactor == 2)
                {
                    ChooseMap.m3 = 1;
                }
            }

            gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
        }
    }

}
