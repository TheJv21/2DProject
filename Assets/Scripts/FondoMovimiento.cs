using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{

    [SerializeField] private Vector2 velocidadMovimiento;
    [SerializeField] private GameObject jugador;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D jugadorRB;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        jugadorRB = jugador.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        offset = (jugadorRB.velocity.x * 0.1f) * velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }

}
