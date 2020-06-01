using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------
    // Singleton
    //----------------------------------------------------------------------------------------------------------------
    public static BuildManager instance;
    public GameObject _buildEffect;
    
    //----------------------------------------------------------------------------------------------------------------
    // Serialized fields
    //----------------------------------------------------------------------------------------------------------------
    //    public GameObject standartTurretPrefab;
    //    public GameObject bombTurretPrefab;

    //----------------------------------------------------------------------------------------------------------------
    // Non-serialized fields
    //----------------------------------------------------------------------------------------------------------------
    private TurretBlueprint _turretToBuild;
    private NodeInterations _selectedNode;

    public NodeUI nodeUI;

    //----------------------------------------------------------------------------------------------------------------
    // Unity events
    //----------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        //_turretToBuild = _standartTurretPrefab;
    }

    //----------------------------------------------------------------------------------------------------------------
    // Public methods
    //----------------------------------------------------------------------------------------------------------------
    public bool CanBuild => _turretToBuild != null; // if there's not a turret it returns true
    public bool HasMoney => PlayerStats.Money >= _turretToBuild.cost;

    public void SelectNode(NodeInterations node)
    {
        if (_selectedNode == node)
        {
            DeselectNode();
        }
        
        _selectedNode = node;
        _turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        _selectedNode = null;
        nodeUI.Hide();
    }
    
    public void SetTurretToBuild(TurretBlueprint turret)
    {
        _turretToBuild = turret;
        DeselectNode();
    }
    
    public TurretBlueprint GetTurretToBuild()
    {
        return _turretToBuild;
    }

//    public void SetTurretToBuild(GameObject turret)
//    {
//        _turretToBuild = turret;
//    }
}
