using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlJugador : MonoBehaviour
{
  
    private Movimiento movimiento;
    private Vector2 entradaControlMov;
    private LanzaProyectiles lanzaProyectiles;
    private Rigidbody2D rb;
    private float moveSpeed, dirX, dirY;
    public bool ClimbingAllowed { get; set; }

    void Start()
    {
        movimiento = GetComponent<Movimiento>();
        lanzaProyectiles = GetComponent<LanzaProyectiles>();
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;

    }


    void Update()
    {
        movimiento.MoverseEnX(entradaControlMov.x);
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (ClimbingAllowed)
        {
            dirY = Input.GetAxisRaw("Vertical") * moveSpeed;
        }

    }
    private void FixedUpdate()
    {
        if (ClimbingAllowed)
        {
            rb.isKinematic = true;
            rb.velocity = new Vector2(dirX, dirY);
        }
        else
        {
            rb.isKinematic = false;
            rb.velocity = new Vector2(dirX, rb.velocity.y);
        }
    }

    public void AlMoverse(InputAction.CallbackContext context)
    {
        
        movimiento.VoltearTransform(entradaControlMov.x);
        entradaControlMov = context.ReadValue<Vector2>();

    }

    public void AlSaltar(InputAction.CallbackContext context)
    {
        movimiento.Saltar (context.action.triggered);
        
    }

    public void AlLanzar(InputAction.CallbackContext context)
    {
        Debug.Log("boton de disparo apachado");
        if (!context.action.triggered) { return; }
        lanzaProyectiles.Lanzar();
    }

}

