using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class SugarSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject sugar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    { 
        yield return new WaitForSeconds(Random.Range(3,7));
        var rotation = transform.rotation;
        Instantiate(sugar, 
            new Vector3(transform.position.x,10f,transform.position.z),
            UnityEngine.Quaternion.Euler(90,rotation.y,rotation.z));
        StartCoroutine(spawn());
    }
    
}
