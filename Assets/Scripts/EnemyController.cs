using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : Damagable
{
    [SerializeField] private int scorePerKill = 1;
    public static event Action<int> EnemyKilledFunc;
    public PlayerShootController player = null;

    protected override void OnMouseDown()
    {
        if (player == null) return;
        player.Shoot(this);
        base.OnMouseDown();
    }

    protected override void HealthCheck()
    {
        if(health <= 0)
        {
            EnemyKilledFunc?.Invoke(scorePerKill);
            Destroy(gameObject);
        }
    }
}
