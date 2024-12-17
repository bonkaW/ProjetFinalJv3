using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;

public class WaveSpawner : MonoBehaviour
{




    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveNumber = 0;
    public MRUKAnchor.SceneLabels spawnLabels;
    public float minEdgeDistance = 0.3f;

    public AudioSource audioSource;
    public AudioClip victoryClip;


    // public Transform spawnPoint;
    
    void Update()
    {

        if(EnemiesAlive > 0){

            return;

        }


        if(countdown <= 0f) {

            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

    }

    IEnumerator SpawnWave() {

        
        Wave wave = waves[waveNumber];

        for (int i = 0; i < wave.count; i++){

            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);

        }
        waveNumber++;

        if(waveNumber == waves.Length ){

            //FIN DE NIVEAU (UI OU SKIP AU PROCHAIN NIVEAU)

            
            audioSource.PlayOneShot(victoryClip);
            

            Debug.Log("LEVEL WON!");
            this.enabled = false;

        }

    }

    void SpawnEnemy(GameObject enemy){

        MRUKRoom room = MRUK.Instance.GetCurrentRoom();


        room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.VERTICAL, minEdgeDistance, LabelFilter.Included(spawnLabels), out Vector3 pos, out Vector3 norm);

        Vector3 randomPosition = Random.insideUnitSphere * 3;
        randomPosition.y = 0;

        Instantiate(enemy, randomPosition, Quaternion.identity);
        EnemiesAlive++;

    }
}
