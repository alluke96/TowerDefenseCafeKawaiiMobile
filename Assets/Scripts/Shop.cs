using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
   //----------------------------------------------------------------------------------------------------------------
   // Serialized fields
   //----------------------------------------------------------------------------------------------------------------
   [SerializeField] private TurretBlueprint _standartTurret;
   [SerializeField] private TurretBlueprint _bombTurret;   
   [SerializeField] private TurretBlueprint _sugarTurret;

   [SerializeField] private Text _sugarText;
   
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

   private void Update()
   {
      _sugarText.text = "" + PlayerStats.Money;
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
