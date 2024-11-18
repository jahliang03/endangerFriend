using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    public GameObject destination; // The player or target object
    private NavMeshAgent agent; // NavMeshAgent for pathfinding
    public GameObject bulletPrefab; // The bullet prefab
    public Transform shootPoint; // Point from which bullets are spawned
    public float shootingRange = 100f; // Range within which the enemy can shoot
    public float bulletSpeed = 100f; // Speed of the bullets
    public float timeBetweenShots = 1f; // Time interval between shots

    private float nextShotTime = 0f; // Tracks when the enemy can shoot again

    void Start()
    {
        // Initialize the NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing on the enemy!");
        }
    }

    void Update()
    {
        // Set the enemy's destination to the player's position
        if (destination != null)
        {
            agent.destination = destination.transform.position;

            // Check if the player is within shooting range
            float distanceToPlayer = Vector3.Distance(transform.position, destination.transform.position);
            if (distanceToPlayer <= shootingRange)
            {
                ShootAtPlayer();
            }
        }
    }

    void ShootAtPlayer()
    {
        // Check if it's time to shoot
        if (Time.time >= nextShotTime)
        {
            // Instantiate the bullet at the shoot point
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

            // Calculate the direction to the player
            Vector3 direction = (destination.transform.position - shootPoint.position).normalized;

            // Rotate the bullet to face the player
            bullet.transform.rotation = Quaternion.LookRotation(direction);

            // Apply velocity to the bullet
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }

            // Set the next shot time
            nextShotTime = Time.time + timeBetweenShots;

            // Destroy the bullet after 5 seconds to prevent clutter
            Destroy(bullet, 5f);
        }
    }
}
