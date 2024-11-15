using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class enemyAI : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent enemy;

    public Transform player; 
    void Start()
    {

    }
    void Update()
    {
        //transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 1 * Time.deltaTime);
        enemy.SetDestination(player.position);
    }
}