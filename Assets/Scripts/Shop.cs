using UnityEngine;

public class Shop : MonoBehaviour
{
   //----------------------------------------------------------------------------------------------------------------
   // Serialized fields
   //----------------------------------------------------------------------------------------------------------------
   [SerializeField] private TurretBlueprint standartTurret;
   [SerializeField] private TurretBlueprint bombTurret;
   
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
      //Debug.Log("Bought standart turret");
      _buildManager.SetTurretToBuild(standartTurret);
   }
   
   public void SelectBombTurret()
   {
      //Debug.Log("Bought bomb turret");
      _buildManager.SetTurretToBuild(bombTurret);
   }
}
