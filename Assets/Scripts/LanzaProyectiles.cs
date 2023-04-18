using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaProyectiles : MonoBehaviour, IAtaque
{
	[SerializeField] private GameObject proyectilPrefab;
	[SerializeField] private Transform puntoDeSalida;

	private Equipo equipo;

    public float ataque { get => ataque_; set => ataque_ = value; }

	[SerializeField] private float ataque_ = 1f;

	private void Awake()
	{
		equipo = GetComponent<Equipo>();
	}

	public void Lanzar()
	{
		GameObject instanciaProyectil = Instantiate(proyectilPrefab, puntoDeSalida.position, transform.rotation);
		Proyectil proyectil = instanciaProyectil.GetComponent<Proyectil>();
		proyectil.AjustarAtaque(ataque);
		proyectil.AjustarDireccion(new Vector2(Mathf.Sign(transform.localScale.x), 0));
		proyectil.AjustarEquipoEnum(equipo.EquipoActual);
		
	}
}
