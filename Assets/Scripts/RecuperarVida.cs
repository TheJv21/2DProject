using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecuperarVida : MonoBehaviour
{
    [SerializeField] float recVida = 2f;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.TryGetComponent<Salud>(out Salud vida))
        {
            vida.RecuperarVida(recVida);
            Destroy(gameObject);
        }
    }
}
