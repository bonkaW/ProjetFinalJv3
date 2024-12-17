using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;

public class spawner : MonoBehaviour
{

    public float spawnTimer = 1;

    public GameObject prefabToSpawn;

    private float timer;

    public float minEdgeDistance = 0.3f;
    public MRUKAnchor.SceneLabels spawnLabels;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!MRUK.Instance && !MRUK.Instance.IsInitialized)
            return;

        timer += Time.deltaTime;
        if (timer > spawnTimer)
        {
            SpawnEnemy();
            timer -= spawnTimer;
        }

    }

    public void SpawnEnemy()
    {

        MRUKRoom room = MRUK.Instance.GetCurrentRoom();


        room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.VERTICAL, minEdgeDistance, LabelFilter.Included(spawnLabels), out Vector3 pos, out Vector3 norm);

        Vector3 randomPosition = Random.insideUnitSphere * 3;
        randomPosition.y = 0;

        Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);

    }
}
