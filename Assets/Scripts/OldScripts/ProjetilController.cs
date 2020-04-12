using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilController : MonoBehaviour
{
    private GameController _gameController;
    
    private AudioSource hit;
    [SerializeField] private AudioClip pop;

    private void Start()
    {
        hit = GetComponent<AudioSource>();
        hit.clip = pop;
        _gameController = GameController.Instance;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Verificar se a bala é de morango e se o inimigo é vermelho
        if (other.gameObject.CompareTag("InimigoVermelho") && gameObject.GetComponent<SpriteRenderer>().sprite.name == "morango")
        {
            Destroy(other.gameObject);
            _gameController.Score();
            hit.Play();
        }
                if (other.gameObject.CompareTag("InimigoVermelho") && gameObject.GetComponent<SpriteRenderer>().sprite.name != "morango")
                    Destroy(other.gameObject);
                
        // Verificar se a bala é de limao e se o inimigo é verde
        if (other.gameObject.CompareTag("InimigoVerde") && gameObject.GetComponent<SpriteRenderer>().sprite.name == "limao")
        {
            Destroy(other.gameObject);
            _gameController.Score();
            hit.Play();
        }
                if (other.gameObject.CompareTag("InimigoVerde") && gameObject.GetComponent<SpriteRenderer>().sprite.name != "limao")
                    Destroy(other.gameObject);
                
                
        Destroy(gameObject);
    }



}
