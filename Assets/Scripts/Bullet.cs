using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 10f;
    public GameObject impactEffect;

    // Pour faire tourner le projectile
    public Transform Fleche;
    public float turnSpeed = 5f;

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

        // Pour faire tourner le projectile
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(Fleche.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        Fleche.rotation = Quaternion.Euler(rotation.z, rotation.y, rotation.z);

        if(dir.magnitude <= distanceThisFrame){
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget(){
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        //Destroy(target.gameObject); //Temporaire pour détruire l'ennemi
        Destroy(gameObject);
    }
}
