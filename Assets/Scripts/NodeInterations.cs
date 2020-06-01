using System;
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

    [HideInInspector] public GameObject turret;
    [HideInInspector] public TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded;
    
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
        
        if (turret != null) // if there's already a turret at that node
        {
            _buildManager.SelectNode(this);
            Debug.Log("Can't build there!");
            return;
        }
        
        if (!_buildManager.CanBuild)
            return;
        
        //Build a turret
        BuildTurret(_buildManager.GetTurretToBuild());
    }

    private void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= blueprint.cost; // pay
        
        GameObject _turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.Euler(90,0,0), transform.parent);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = Instantiate(_buildManager._buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        
        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }

    private void OnMouseEnter()
    {
        //if (_buildManager.GetTurretToBuild() == null)
        if (!_buildManager.CanBuild)
            return;

        if (_buildManager.HasMoney)
            _renderer.material.color = _hoverColor;
        else
            _renderer.material.color = Color.red; // not enough money;

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
    
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost; // pay
        Destroy(turret); // Get rid of the old one
        
        GameObject _turret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.Euler(90,0,0), transform.parent);
        turret = _turret;

        GameObject effect = Instantiate(_buildManager._buildEffect, GetBuildPosition(), Quaternion.identity); // we can make another particle effect later
        Destroy(effect, 5f);

        isUpgraded = true;
        
        Debug.Log("Turret upgraded! Money left: " + PlayerStats.Money);
    }
    
    
    public void SellTurret()
    {
        // we can implement another particle effect here :)
        Destroy(turret);
        turretBlueprint = null;
    }
}
