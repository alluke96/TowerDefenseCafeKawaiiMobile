using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------
    // Serialized fields
    //----------------------------------------------------------------------------------------------------------------
    [SerializeField] private float speed = 10f;
    [SerializeField] private  GameObject _listOfWaypointObjects;
    
    //-----------------------------------------------------------------------------------------------------------------
    // Non-serializable fields
    //-----------------------------------------------------------------------------------------------------------------
    public GameObject ListOfWaypointObjects
    {
        get => _listOfWaypointObjects;
        set => _listOfWaypointObjects = value;
    }

    private Transform _target;
    private int _wavePointIndex = 0;
    private CreateWaypointsList _waypointList;
    
    //----------------------------------------------------------------------------------------------------------------
    // Unity events
    //----------------------------------------------------------------------------------------------------------------
    private void Start()
    {
        _waypointList = _listOfWaypointObjects.GetComponent<CreateWaypointsList>();
        _target = _waypointList.listOfWaypointObjects[0];
    }
    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * (speed * Time.deltaTime), Space.World); 
        // normalized to use only the "speed" to control the speed.
        
        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }
    //----------------------------------------------------------------------------------------------------------------
    // Private methods
    //----------------------------------------------------------------------------------------------------------------
    private void GetNextWaypoint()
    {
        if (_wavePointIndex > _waypointList.listOfWaypointObjects.Length)
        {
            Destroy(gameObject);
        }
        _wavePointIndex++;
        _target = _waypointList.listOfWaypointObjects[_wavePointIndex];
    }
}
