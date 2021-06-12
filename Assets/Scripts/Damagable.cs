using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damagable : MonoBehaviour
{
    public int MaxHealth { get; set; } = 1;
    public int health = 1;

    private void Awake()
    {
        health = MaxHealth;
    }

    protected virtual void OnMouseDown()
    {
        HealthCheck();
    }

    protected virtual void HealthCheck()
    {

    }
}
