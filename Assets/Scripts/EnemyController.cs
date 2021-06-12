using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Damagable
{
    [SerializeField] private PlayerShootController player = null;

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
            Destroy(gameObject);
        }
    }
}
