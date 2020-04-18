using System;
using UnityEngine;

public class Node : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------
    // Serialized fields
    //----------------------------------------------------------------------------------------------------------------
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Vector3 offset;

    //----------------------------------------------------------------------------------------------------------------
    // Non-serialized fields
    //----------------------------------------------------------------------------------------------------------------
    private Renderer _renderer;
    private Color _startColor;
    private GameObject _turret;

    //----------------------------------------------------------------------------------------------------------------
    // Unity events
    //----------------------------------------------------------------------------------------------------------------
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
    }

    private void OnMouseDown()
    {
        if (_turret != null) // if there's already a turret at that node
        {
            Debug.Log("Can't build there!");
            return;
        }
        
        //Build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        Instantiate(turretToBuild, transform.position + offset, transform.rotation, transform.parent);
    }

    private void OnMouseEnter()
    {
       _renderer.material.color = _hoverColor;
    }
    
    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
}
