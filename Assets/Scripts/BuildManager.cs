using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------
    // Singleton
    //----------------------------------------------------------------------------------------------------------------
    public static BuildManager instance;
    
    //----------------------------------------------------------------------------------------------------------------
    // No-serialized fields
    //----------------------------------------------------------------------------------------------------------------
//    public GameObject standartTurretPrefab;
//    public GameObject bombTurretPrefab;
    
    //----------------------------------------------------------------------------------------------------------------
    // Non-serialized fields
    //----------------------------------------------------------------------------------------------------------------
    private TurretBlueprint _turretToBuild;

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

    public void BuildTurretOnNode(NodeInterations node)
    {
        if (PlayerStats.Money < _turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= _turretToBuild.cost; // pay
        
        GameObject turret = Instantiate(_turretToBuild.prefab, node.GetBuildPosition(), Quaternion.Euler(90,0,0), node.transform.parent);
        node.turret = turret;
        
        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }
    
    public void SetTurretToBuild(TurretBlueprint turret)
    {
        _turretToBuild = turret;
    }
    
//    public GameObject GetTurretToBuild()
//    {
//        return _turretToBuild;
//    }

//    public void SetTurretToBuild(GameObject turret)
//    {
//        _turretToBuild = turret;
//    }
}
