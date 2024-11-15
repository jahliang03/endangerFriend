using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public Transform targetObj; // Player or target object
    public GameObject enemyBullet; // Bullet prefab
    public Transform spawnPoint; // Spawn point of bullets
    public float enemySpeed = 2f; // Movement speed of the enemy

    public float shootingRange = 10f; // Distance within which the enemy can shoot
    public float timeBetweenShots = 2f; // Time interval between shots
    public float bulletSpeed = 10f; // Speed of the bullets

    private float nextShotTime = 0f; // Tracks when the enemy can shoot again

    void Start()
    {
        // Initialize variables if needed
    }

    void Update()
    {
        // Move toward the player
        MoveTowardsPlayer();

        // Try to shoot at the player
        TryShootPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Move the enemy toward the player continuously
        transform.position = Vector3.MoveTowards(transform.position, targetObj.position, enemySpeed * Time.deltaTime);
    }

    void TryShootPlayer()
    {
        // Check if the player is within range and if it's time to shoot
        if (Time.time >= nextShotTime && Vector3.Distance(transform.position, targetObj.position) <= shootingRange)
        {
            ShootAtPlayer();
            nextShotTime = Time.time + timeBetweenShots; // Schedule the next shot
        }
    }

    void ShootAtPlayer()
    {
        // Instantiate a bullet at the spawn point
        GameObject bullet = Instantiate(enemyBullet, spawnPoint.position, Quaternion.identity);

        // Calculate direction to the player
        Vector3 direction = (targetObj.position - spawnPoint.position).normalized;

        // Rotate the bullet to face the player
        bullet.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

        // Apply velocity to the bullet to propel it toward the player
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed; // Adjust bullet speed
        }
    }
}
