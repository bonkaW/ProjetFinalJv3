using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public spawner waveSpawner; // Reference to the spawner
    private bool isDead = false;

    // Call this function when the enemy dies
    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            // Notify the spawner that this enemy has died
            if (waveSpawner != null)
            {
                waveSpawner.EnemyDied();
            }

            
        }
    }
}
