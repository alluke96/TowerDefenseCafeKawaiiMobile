using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    //----------------------------------------------------------------------------------------------------------------
    // Non-serializable fields
    //----------------------------------------------------------------------------------------------------------------
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;
}
