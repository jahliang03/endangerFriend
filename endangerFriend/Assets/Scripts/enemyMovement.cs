using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class enemyMovement : MonoBehaviour
{
    public GameObject destination; 
    private NavMeshAgent agent; 
    public GameObject bulletPrefab; 
    void Start(){
        agent = GetComponent<NavMeshAgent>(); 
    }
    void Update(){
        agent.destination = destination.transform.position; 
    }
   
}
