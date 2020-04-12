using System;
using UnityEngine;

public class CreateWaypointsList : MonoBehaviour
{
    //-----------------------------------------------------------------------------------------------------------------
    // Non-serializable fields
    //-----------------------------------------------------------------------------------------------------------------
    public Transform[] listOfWaypointObjects;

    //-----------------------------------------------------------------------------------------------------------------
    // Unity events
    //-----------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        listOfWaypointObjects = new Transform[transform.childCount];
        for (int i = 0; i < listOfWaypointObjects.Length; i++)
        {
            listOfWaypointObjects[i] = transform.GetChild(i);
        }
    }
}
