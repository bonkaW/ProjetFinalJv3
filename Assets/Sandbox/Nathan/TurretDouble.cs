using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDouble : MonoBehaviour
{
    private Transform target;

    [Header("Attributs")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    private bool firePointAReady = true;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    // Pour faire tourner la tourelle
    public Transform Tete;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePointA;
    public Transform firePointB;


    void Start(){
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range){
            target = nearestEnemy.transform;
        }
        else{
            target = null;
        }

    }

    void Update(){
        if(target == null)
            return;

        // Pour faire tourner la tourelle
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(Tete.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        Tete.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown <= 0f && firePointAReady == true){
            ShootA();
            fireCountdown = 1f / fireRate;
            firePointAReady = false;
        }
        else if (fireCountdown <= 0f &&firePointAReady == false){
            ShootB();
            fireCountdown = 1f / fireRate;
            firePointAReady = true;
        }

        fireCountdown -= Time.deltaTime;
    }

    void ShootA(){
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePointA.position, firePointA.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
            bullet.Seek(target);
    }

    void ShootB(){
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePointB.position, firePointB.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
            bullet.Seek(target);
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
