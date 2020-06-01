using UnityEngine;

public class Shop : MonoBehaviour
{
   //----------------------------------------------------------------------------------------------------------------
   // Serialized fields
   //----------------------------------------------------------------------------------------------------------------
   [SerializeField] private TurretBlueprint _standartTurret;
   [SerializeField] private TurretBlueprint _bombTurret;   
   [SerializeField] private TurretBlueprint _sugarTurret;
   
   //----------------------------------------------------------------------------------------------------------------
   // Non-serialized fields
   //----------------------------------------------------------------------------------------------------------------
   private BuildManager _buildManager;

   //----------------------------------------------------------------------------------------------------------------
   // Unity events
   //----------------------------------------------------------------------------------------------------------------
   private void Start()
   {
      _buildManager = BuildManager.instance;
   }

   //----------------------------------------------------------------------------------------------------------------
   // Public methods
   //----------------------------------------------------------------------------------------------------------------
   public void SelectStandartTurret()
   {
      _buildManager.SetTurretToBuild(_standartTurret);
   }
   
   public void SelectBombTurret()
   {
      _buildManager.SetTurretToBuild(_bombTurret);
   }
   
   public void SelectSugarTurret()
   {
      _buildManager.SetTurretToBuild(_sugarTurret);
   }
}
