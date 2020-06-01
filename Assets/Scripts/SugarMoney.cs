using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarMoney : MonoBehaviour
{
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        PlayerStats.Money += 25;
    }
}
