using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject mainPlayer = null;
    [SerializeField]
    GameObject prefab = null;

    [SerializeField] EnemyController enemyPrefab = null;
    [SerializeField] PlayerShootController playerShootControllerRef = null;
    float timeSinceLastEnemyInstantiation = 0;
    float enemyInstantiationRate = 2f;
    EnemyWalkingBounds enemyBounds;

    [SerializeField]
    private float minX, maxX, minY, maxY;
    private int howManyPlayers = 4;

    //Collections
    private LineRenderer[] instances;
    public static List<Transform> PrefabTransforms { get; private set; } = new List<Transform>();

    private void Awake()
    {
        //Init EnemyBounds
        enemyBounds = new EnemyWalkingBounds(transform, 32f);

        //Init OnPlayerDeath
        PlayerCollision.PlayerDeathFunc += OnPlayerDeath;

        //Init Arrays
        instances = new LineRenderer[howManyPlayers];
        PrefabTransforms.Add(mainPlayer.transform);

        InstantiatePrefabs();

        OneTimeLink();
    }

    private void InstantiateEnemyPrefab()
    {
        if (enemyPrefab == null || playerShootControllerRef == null) return;
        if(timeSinceLastEnemyInstantiation <= 0)
        {
            EnemyController enemyController = Instantiate(enemyPrefab, new Vector3(enemyBounds.RangeX(), enemyBounds.RangeY(), -60), Quaternion.identity);
            enemyController.player = playerShootControllerRef;
            timeSinceLastEnemyInstantiation = enemyInstantiationRate;
            return;
        }
        timeSinceLastEnemyInstantiation -= Time.deltaTime;
    }

    private void InstantiatePrefabs()
    {
        for (int i = 0; i < howManyPlayers; i++)
        {
            GameObject instance = Instantiate(prefab, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
            PrefabTransforms.Add(instance.transform);
            Vector3 prefabTransformPosition = PrefabTransforms[i + 1].position;
            prefabTransformPosition.z = -60;
            PrefabTransforms[i + 1].position = prefabTransformPosition;
            instances[i] = instance.GetComponent<LineRenderer>();
        }
    }

    private void Update()
    {
        CreateLink();

        InstantiateEnemyPrefab();
    }

    private void CreateLink()
    {
        foreach(LineRenderer instance in instances)
        {
            if (instance == null || mainPlayer == null) continue;
            Transform instanceTransform = instance.transform;
            instance.SetPositions(new Vector3[] { new Vector3(instanceTransform.position.x, instanceTransform.position.y, -50), mainPlayer.transform.position });
        }
    }

    private void OneTimeLink()
    {
        foreach(LineRenderer instance in instances)
        {
            if (instance == null) continue;
            instance.sortingLayerName = "Line";
            instance.alignment = LineAlignment.TransformZ;
            instance.startWidth = 0.2f;
            instance.endWidth = 0.5f;
        }
    }

    private void OnPlayerDeath(Transform playerTransform)
    {
        for(int i = 0; i < PrefabTransforms.Count; i++)
        {
            if (PrefabTransforms[i] == playerTransform)
            {
                PrefabTransforms.RemoveAt(i);
            }
        }
    }
}
