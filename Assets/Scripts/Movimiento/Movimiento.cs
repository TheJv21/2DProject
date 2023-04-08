using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float velCaminar = 4f;
    //[SerializeField] private float velInicialDeSalto = 5.0f;
    [SerializeField] private float alturaSalto = 5.0f;
    [SerializeField] private LayerMask capasSalto;
    [SerializeField] private int cantidad_saltos = 1;
    [Range(0, 1)]
    [SerializeField] private float modificadorVelSalto = 0.5f;
    private int cantidad;


    private Rigidbody2D rb;
    private BoxCollider2D boxcollaider;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxcollaider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {

        if (boxcollaider.IsTouchingLayers())
        {
            cantidad = cantidad_saltos;
        }

    }

    public void MoverseEnX(float movimientoX)
    {
        rb.velocity = new Vector2(movimientoX * velCaminar, rb.velocity.y);
        if (animator != null)
        {
            animator.SetBool("estaCorriendo", Mathf.Abs(movimientoX)> Mathf.Epsilon);
        }
    }

    public void Saltar(bool valor)
    {
        float gravedad = Physics2D.gravity.y * rb.gravityScale;
        float velinicialDeSalto = Mathf.Sqrt((-2 * gravedad * alturaSalto));
        if (boxcollaider.IsTouchingLayers())
        {
            if (valor && cantidad > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, velinicialDeSalto);
            }
        }
        else if (!boxcollaider.IsTouchingLayers())
        {
            if (valor && cantidad > 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, velinicialDeSalto);
                cantidad--;
            }
        }
        else
        {
            if(rb.velocity.y > Mathf.Epsilon)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * modificadorVelSalto);
            }
        }
    }
        public void VoltearTransform(float movimientoX)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * Mathf.Sign(movimientoX), transform.localScale.y);

        }
}