using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    [SerializeField] private Transform detector;
    [SerializeField] private float distanciaAlSuelo= 0.3f;

    [SerializeField] private LayerMask layersuelo;


    private Movimiento movimiento;
    Vector2 direccionMoviemiento;

    void Start()
    {
        movimiento = GetComponent<Movimiento>();
        direccionMoviemiento = new Vector2(1f,0f);

        
    }

    // Update is called once per frame
    void Update()
    {
        movimiento.VoltearTransform(direccionMoviemiento.x );
        movimiento.MoverseEnX(direccionMoviemiento.x);
        DetectarSuelo();

    }

    private void DetectarSuelo()
    {
        RaycastHit2D raycast = Physics2D.Raycast(detector.position,Vector2.down, distanciaAlSuelo ,layersuelo);
        if (raycast.collider == null)
        {
            direccionMoviemiento.x *= -1f;

        }
    } 
}
