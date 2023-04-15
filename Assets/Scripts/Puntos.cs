using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntos : MonoBehaviour
{
	[SerializeField] private TMP_Text textoPuntos;
	public static float nuevoValorAtaque;
	public static float nuevoValorAtaqueOFF = 0;
	public static float nuevoValorAtaqueON = 10;



	private int contadorPuntos = 0;


	private void Start()
	{
		ActualizarTexto();
		nuevoValorAtaque = 0;

	}

    public void SumarPuntos(int puntos)
	{
		if(puntos == 200)
        {
			contadorPuntos += puntos;
			Debug.Log("SUMO 200");
			StartCoroutine(ONOFF());
		}
		else
        {
			
			contadorPuntos += puntos;
		}
		ActualizarTexto();
		
	}

	public IEnumerator ONOFF()
    {
		Proyectil.valor2=10f;
		yield return new WaitForSeconds(5f);
		Proyectil.valor2 = 1f;
	}
	public void ActualizarTexto()
	{
		textoPuntos.text = contadorPuntos.ToString();
	}
}


