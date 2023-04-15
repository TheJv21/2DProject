using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAtaque : MonoBehaviour
{
    [SerializeField] private int puntosBrindados = 200;


    private bool activado = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activado) { return; }

        if (collision.gameObject.TryGetComponent<Puntos>(out Puntos puntos))
        {
            activado = true;
            puntos.SumarPuntos(puntosBrindados);
            Destroy(gameObject);
        }
    }
}





