using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------
    // Serialized fields
    //----------------------------------------------------------------------------------------------------------------
    [Header("Dependencies")]
    [SerializeField] private Transform _transform;

    [SerializeField] private EnemyController[] _enemiesPrefabs;

    [Header("Settings")]
    [SerializeField] private float _railSpeed = 8f;
    [SerializeField] private float _spawnRate = 2f;

    //----------------------------------------------------------------------------------------------------------------
    // Unity events
    //----------------------------------------------------------------------------------------------------------------
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, _spawnRate);
    }

    //----------------------------------------------------------------------------------------------------------------
    // Private methods
    //----------------------------------------------------------------------------------------------------------------
    private void Spawn()
    {
        int randomEnemyPrefabIndex = Random.Range(0, _enemiesPrefabs.Length);
        EnemyController prefab = _enemiesPrefabs[randomEnemyPrefabIndex];
        EnemyController enemy = Instantiate(prefab, _transform.position, Quaternion.identity, _transform);
        enemy.Initialize(_railSpeed);
    }
}
