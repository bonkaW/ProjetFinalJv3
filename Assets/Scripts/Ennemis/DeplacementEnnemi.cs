using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeplacementEnnemi : MonoBehaviour
{

    public GameObject chateau;
    public NavMeshAgent agent;
    public float speed = 1;

    void Start(){
        chateau = GameObject.FindWithTag("Chateau");
        agent = this.GetComponent<NavMeshAgent>();
    }

    void Update(){
        agent.SetDestination(chateau.transform.position);
        agent.speed = speed;
    }
}
