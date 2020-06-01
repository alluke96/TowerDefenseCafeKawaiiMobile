using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    [SerializeField] private GameObject ui;
    [SerializeField] private Text upgradeCostText;
    [SerializeField] private Button upgradeButton;
    
    private NodeInterations _target;

    public void SetTarget(NodeInterations target)
    {
        _target = target;
        transform.position = _target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCostText.text = "$" + _target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCostText.text = "DONE";
            upgradeButton.interactable = false;
        }
        
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        _target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    
    public void Sell()
    {
        _target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
