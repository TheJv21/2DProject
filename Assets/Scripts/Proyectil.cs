using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
	[SerializeField] private static float ataque = 1f;
	[SerializeField] private float velocidad = 5f;
	[SerializeField] private float tiempoDeVida = 2f;
	private float tiempo = 1f;
	public static float valor2= 1f;
	public float ataque2;
	private Rigidbody2D rb;
	private EquipoEnum equipoEnum;

	private void Update()
	{
		DestruirProyectil();
		ataque2 = ataque;
	}

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();

	}

	public void AjustarEquipoEnum(EquipoEnum equipoEnum)
	{
		this.equipoEnum = equipoEnum;
	}

	public void AjustarDireccion(Vector2 direccion)
	{
		rb.velocity = direccion.normalized * velocidad;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
        if (other.CompareTag("Plataforma")) { Destroy(gameObject); }
		if (!other.gameObject.TryGetComponent<Salud>(out Salud saludDelOtro)) { return; }
		if (!other.gameObject.TryGetComponent<Equipo>(out Equipo equipoDelOtro)) { return; }
		if (equipoDelOtro.EquipoActual == equipoEnum) { return; }
		Debug.Log("ATAQUE - " + ataque);
		if(valor2 == 10)
        {
			tiempo -= Time.deltaTime;
			if (tiempo <= 0)
			{
				saludDelOtro.PerderSalud(ataque + 10);
			}
		}
			saludDelOtro.PerderSalud2(ataque);
		Destroy(gameObject);
	}

	private void DestruirProyectil()
	{

		tiempoDeVida -= Time.deltaTime;
		if (tiempoDeVida <= 0)
		{
			Destroy(gameObject);
		}


	}

}