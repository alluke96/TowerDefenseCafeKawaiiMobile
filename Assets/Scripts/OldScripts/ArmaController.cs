using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaController : MonoBehaviour
{
    [SerializeField] private GameObject projetilPrefab;
    [SerializeField] private Vector2 velBala;
    private GameObject tempObject;
    private AudioSource tiro;
    [SerializeField] private AudioClip fire;

    [SerializeField] private Sprite red, green;

    private void Start()
    {
        tiro = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tempObject = Instantiate(projetilPrefab);
            tempObject.GetComponent<Rigidbody2D>().AddForce(velBala);
            tempObject.transform.position = transform.position;
            tiro.PlayOneShot(fire);
        }

        if (Input.GetKey(KeyCode.Alpha1))
            projetilPrefab.GetComponent<SpriteRenderer>().sprite = red;
        if (Input.GetKey(KeyCode.Alpha2))
            projetilPrefab.GetComponent<SpriteRenderer>().sprite = green;
    }
}
