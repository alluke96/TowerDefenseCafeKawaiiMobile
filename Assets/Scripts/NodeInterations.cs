using UnityEngine;
using UnityEngine.EventSystems;

public class NodeInterations : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------
    // Serialized fields
    //----------------------------------------------------------------------------------------------------------------
    [SerializeField] private Color _hoverColor;

    //----------------------------------------------------------------------------------------------------------------
    // Non-serialized fields
    //----------------------------------------------------------------------------------------------------------------
    private Renderer _renderer;
    private BuildManager _buildManager;

    [Header("Optional")]
    public GameObject turret;
    public Vector3 positionOffset;

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
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!_buildManager.CanBuild)
            return;
        
        if (turret != null) // if there's already a turret at that node
        {
            Debug.Log("Can't build there!");
            return;
        }
        
        //Build a turret
        _buildManager.BuildTurretOnNode(this);
    }

    private void OnMouseEnter()
    {
        //if (_buildManager.GetTurretToBuild() == null)
        if (!_buildManager.CanBuild)
            return;
        
        _renderer.enabled = true;
    }
    
    private void OnMouseExit()
    {
        _renderer.enabled = false;
    }
    
    //----------------------------------------------------------------------------------------------------------------
    // Public methods
    //----------------------------------------------------------------------------------------------------------------
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
