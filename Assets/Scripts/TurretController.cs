using System;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------
    // Serialized fields
    //----------------------------------------------------------------------------------------------------------------
    [Header("Attributes")]
    [SerializeField] private float _shootingRange = 15f;
    [SerializeField] private float _fireRate = 1f;

    [Header("Dependencies")] 
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    
    //----------------------------------------------------------------------------------------------------------------
    // Non-serialized fields
    //----------------------------------------------------------------------------------------------------------------
    private Transform _target;
    private const string EnemyTag = "Enemy";
    private float _fireCountdown = 0f;
    private Transform _parent;

    //----------------------------------------------------------------------------------------------------------------
    // Unity events
    //----------------------------------------------------------------------------------------------------------------
    private void Start()
    {
        _parent = transform.parent;
        InvokeRepeating(nameof(UpdateTarget), 0f,0.5f);
    }

    private void Update()
    {
        if (_target == null)
            return;

        if (_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1f / _fireRate;
        }
        _fireCountdown -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _shootingRange);    
    }

    //----------------------------------------------------------------------------------------------------------------
    // Private methods
    //----------------------------------------------------------------------------------------------------------------
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && enemy.transform.parent == _parent)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= _shootingRange)
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }
    }

    private void Shoot()
    {
        GameObject bulletGO = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        BulletController bullet = bulletGO.GetComponent<BulletController>();

        if (bullet != null)
        {
            bullet.Seek(_target);
        }
    }
}
