using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PivotArma : MonoBehaviour
{
    public int velRotacao;
    void Update()
    {
        //Debug.Log(transform.rotation.eulerAngles.z);
        if (Input.GetKey(KeyCode.W) && transform.rotation.eulerAngles.z <= 80)
            transform.Rotate(0,0,velRotacao);
        if (Input.GetKey(KeyCode.S) && transform.rotation.eulerAngles.z >= 1)
            transform.Rotate(0,0,-velRotacao);
    }
}
