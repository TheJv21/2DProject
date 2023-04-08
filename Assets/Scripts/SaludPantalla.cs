using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaludPantalla : MonoBehaviour
{
	[SerializeField] private Salud Salud;
	[SerializeField] private Image barraSalud;

	private void OnEnable()
	{
		Salud.alActualizarSalud += ActualizarBarra;
	}

	private void OnDisable()
	{
		Salud.alActualizarSalud -= ActualizarBarra;
	}

	private void ActualizarBarra()
	{
		barraSalud.fillAmount = Salud.ObtenerFraccion();
	}
}
