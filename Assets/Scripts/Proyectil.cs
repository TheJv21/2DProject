using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
	[SerializeField] private float velocidad = 5f;
	[SerializeField] private float tiempoDeVida = 2f;
	[SerializeField] private GameObject itemAtaque;


	private Rigidbody2D rb;
	private EquipoEnum equipoEnum;
	private float ataque;

	private void Update()
	{
		DestruirProyectil();
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

	public void AjustarAtaque(float ataque)
	{
		this.ataque = ataque;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
        if (other.CompareTag("Plataforma")) { Destroy(gameObject); }
		if (!other.gameObject.TryGetComponent<Salud>(out Salud saludDelOtro)) { return; }
		if (!other.gameObject.TryGetComponent<Equipo>(out Equipo equipoDelOtro)) { return; }
		if (equipoDelOtro.EquipoActual == equipoEnum) { return; }
		Debug.Log("Ataque proyectil: " + ataque);
		saludDelOtro.PerderSalud(ataque);
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