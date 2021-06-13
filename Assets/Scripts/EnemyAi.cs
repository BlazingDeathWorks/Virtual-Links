using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    Vector3 nextDestination;
    private float initialZ = 0;
    private float timeSinceArrived = -2;
    [SerializeField]
    private float setDestinationRate = 1.5f;

    private void Awake()
    {
        initialZ = transform.position.z;
        SetNextDestination();
    }

    private void SetNextDestination()
    {
        Vector3 scale = transform.localScale;
        nextDestination = DetermineWalkBounds();
        if (nextDestination.x < transform.position.x)
        {
            scale.x = 1;
        }
        else if(nextDestination.x > transform.position.x)
        {
            scale.x = -1;
        }
        transform.localScale = scale;
    }

    private void Update()
    {
        timeSinceArrived += Time.deltaTime;

        if (timeSinceArrived >= setDestinationRate)
        {
            transform.position = nextDestination;
            SetNextDestination();
            timeSinceArrived = 0;
        }
    }

    private Vector3 DetermineWalkBounds()
    {
        EnemyWalkingBounds enemyWalkingBounds = new EnemyWalkingBounds(transform, Random.Range(3f, 6f));
        return new Vector3(enemyWalkingBounds.RangeX(), enemyWalkingBounds.RangeY(), initialZ);
    }
}

//Data class
public class EnemyWalkingBounds
{
    public readonly Vector2 enemyPos;
    public readonly float minX, minY, maxX, maxY;

    public EnemyWalkingBounds(Transform transform, float maxDistanceAway)
    {
        enemyPos = transform.position;

        //Init floats
        minX = enemyPos.x - maxDistanceAway;
        maxX = enemyPos.x + maxDistanceAway;
        minY = enemyPos.y - maxDistanceAway;
        maxY = enemyPos.y + maxDistanceAway;
    }

    public float RangeX()
    {
        float x = Random.Range(minX, maxX);
        return Mathf.Clamp(x, -15, 15);
    }

    public float RangeY()
    {
        float y = Random.Range(minY, maxY);
        return Mathf.Clamp(y, 1, 31);
    }
}
