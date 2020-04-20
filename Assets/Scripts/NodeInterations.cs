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
    private GameObject _turret;

    private BuildManager _buildManager;

    //----------------------------------------------------------------------------------------------------------------
    // Unity events
    //----------------------------------------------------------------------------------------------------------------
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (_turret != null) // if there's already a turret at that node
        {
            Debug.Log("Can't build there!");
            return;
        }
        
        //Build a turret
        GameObject turretToBuild = _buildManager.GetTurretToBuild();
        _turret = Instantiate(turretToBuild, transform.position + _positionOffset, Quaternion.Euler(90,0,0), transform.parent);
    }

    private void OnMouseEnter()
    {
        if (_buildManager.GetTurretToBuild() == null)
            return;
        _renderer.enabled = true;
    }
    
    private void OnMouseExit()
    {
        _renderer.enabled = false;
    }
}
