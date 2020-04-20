using UnityEngine;

public class BulletController : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------
    // Serialized fields
    //----------------------------------------------------------------------------------------------------------------
    [SerializeField] private float _speed = 70f;
    [SerializeField] private int _damage = 25;
    [SerializeField] private GameObject _particlesBulletImpact;
    
    //----------------------------------------------------------------------------------------------------------------
    // Non-serialized fields
    //----------------------------------------------------------------------------------------------------------------
    private Transform _target;
    
    //----------------------------------------------------------------------------------------------------------------
    // Unity events
    //----------------------------------------------------------------------------------------------------------------
    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = _target.position - transform.position;
        float distanceThisFrame = _speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    //----------------------------------------------------------------------------------------------------------------
    // Private methods
    //----------------------------------------------------------------------------------------------------------------
    private void HitTarget()
    {
        //Debug.Log("Hit something");
        GameObject effectInstance = Instantiate(_particlesBulletImpact, transform.position, transform.rotation);
        
        Damage(_target);
        
        Destroy(effectInstance, 2f); // Clean Hierarchy
        Destroy(gameObject); // Destroy bullet
    }

    private void Damage(Transform enemy)
    {
        EnemyController e = enemy.GetComponent<EnemyController>();
        if (e != null)
        {
            e.TakeDamage(_damage);
        }
    }
    
    //----------------------------------------------------------------------------------------------------------------
    // Public methods
    //----------------------------------------------------------------------------------------------------------------
    public void Seek(Transform target)
    {
        _target = target;
    }
}
