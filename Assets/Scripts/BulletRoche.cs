using UnityEngine;

public class BulletRoche : MonoBehaviour
{
    private Transform target;

    public float speed = 10f;
    public GameObject impactEffect;

    public void Seek (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame){
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget(){
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Destroy(target.gameObject); //Temporaire pour détruire l'ennemi
        Destroy(gameObject);

        WaveSpawner.EnemiesAlive--;

        GoldManager goldManager = FindObjectOfType<GoldManager>();
        if (goldManager != null)
        {
            int goldReward = 5;
            goldManager.Addgold(goldReward);
        }
    }
}
