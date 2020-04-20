using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------
    // Serialized fields
    //----------------------------------------------------------------------------------------------------------------
    [Header("Settings")]
    [SerializeField] private float _timeBetweenWaves = 5f;
    [Header("Dependencies")] 
    [SerializeField] private Transform[] _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoint;

    //----------------------------------------------------------------------------------------------------------------
    // Non-serialized fields
    //----------------------------------------------------------------------------------------------------------------
    private float _countdown = 2f; // value is set for the first wave
    private int _waveIndex = 0;
    
    //----------------------------------------------------------------------------------------------------------------
    // Unity events
    //----------------------------------------------------------------------------------------------------------------
    private void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = _timeBetweenWaves;
        }

        _countdown -= Time.deltaTime;
    }

    //----------------------------------------------------------------------------------------------------------------
    // Coroutines
    //----------------------------------------------------------------------------------------------------------------
    private IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incoming!");
        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        _waveIndex++;
    }

    //----------------------------------------------------------------------------------------------------------------
    // Private methods
    //----------------------------------------------------------------------------------------------------------------
    private void SpawnEnemy()
    {
        int randomRow = Random.Range(0, _spawnPoint.Length);
        int randomEnemy = Random.Range(0, _enemyPrefab.Length);
        Transform enemy = Instantiate(_enemyPrefab[randomEnemy], _spawnPoint[randomRow].position, Quaternion.Euler(90,0,0), _spawnPoint[randomRow].parent.parent);
        Transform waypointsList = _spawnPoint[randomRow].transform.parent.gameObject.transform.parent.gameObject.transform.Find("WaypointsList");
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        enemyController.ListOfWaypointObjects = waypointsList.gameObject;
    }
}
