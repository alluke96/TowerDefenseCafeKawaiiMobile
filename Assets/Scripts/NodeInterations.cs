using UnityEngine;

public class NodeInterations : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------
    // Serialized fields
    //----------------------------------------------------------------------------------------------------------------
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Vector3 _positionOffset;

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
        Instantiate(turretToBuild, transform.position + _positionOffset, Quaternion.Euler(90,0,0), transform.parent);
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
