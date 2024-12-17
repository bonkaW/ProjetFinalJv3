using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;

public class spawner : MonoBehaviour
{

    [System.Serializable]
    public class Enemywave
    {
        public GameObject prefabToSpawn;
        public int count;
    }


    public float spawnTimer = 1;
    public float waveDelay = 5;
    private float timer;
    private int currentWaveIndex = 0;
    private bool isSpawningWave = false;
    private int aliveEnemies = 0;


    public List<Enemywave> waves;
    public float minEdgeDistance = 0.3f;
    public MRUKAnchor.SceneLabels spawnLabels;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {

        if (!MRUK.Instance && !MRUK.Instance.IsInitialized)
            return;


        if (isSpawningWave && aliveEnemies <= 0 && waves[currentWaveIndex].count > 0)
        {
            timer += Time.deltaTime;

            if (timer > spawnTimer)
            {
                SpawnEnemy(waves[currentWaveIndex]);
                timer = 0;
            }

        }
    }

    public void SpawnEnemy(Enemywave wave)
    {

        MRUKRoom room = MRUK.Instance.GetCurrentRoom();


        room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.VERTICAL, minEdgeDistance, LabelFilter.Included(spawnLabels), out Vector3 pos, out Vector3 norm);

        Vector3 randomPosition = Random.insideUnitSphere * 3;
        randomPosition.y = 0;

        GameObject enemy = Instantiate(wave.prefabToSpawn, randomPosition, Quaternion.identity);

        aliveEnemies++;

        Enemy2 enemyScript = enemy.GetComponent<Enemy2>();
        if (enemyScript != null)
        {
            enemyScript.waveSpawner = this;
        }

        wave.count--;

        //if (wave.count <= 0)
        //{
        //    isWaveComplete = true;
        //}

    }

    public void EnemyDied()
    {
        aliveEnemies--;

        if (aliveEnemies <= 0 && waves[currentWaveIndex].count <= 0)
        {
            isSpawningWave = false;
        }
    }

    private IEnumerator SpawnWaves()
    {
        while (currentWaveIndex < waves.Count)
        {

            isSpawningWave = true;
            timer = 0;
            aliveEnemies = 0;

            while (aliveEnemies > 0 || waves[currentWaveIndex].count > 0)
            {
                yield return null;
            }

            yield return new WaitForSeconds(waveDelay);

            currentWaveIndex++;

        }

        Debug.Log("All waves completed!");
    }


}

