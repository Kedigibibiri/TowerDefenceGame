using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    [Tooltip("Adds amount maxHitPoint when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitPoint = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHitPoint = maxHitPoint;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        
    }
    void ProcessHit()
    {
        currentHitPoint--;
        if (currentHitPoint <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoint += difficultyRamp;
            enemy.RewardGold();

        }
    }
}
