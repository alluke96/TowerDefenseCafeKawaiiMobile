using System;
using UnityEngine;

public class Shop : MonoBehaviour
{
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
   public void PurchaseStandartTurret()
   {
      Debug.Log("Bought standart turret");
      _buildManager.SetTurretToBuild(_buildManager.standartTurretPrefab);
   }
   
   public void PurchaseAnotherTurret()
   {
      Debug.Log("Bought bomb turret");
      _buildManager.SetTurretToBuild(_buildManager.bombTurretPrefab);
   }
}
