using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Salud : MonoBehaviour
{
	[SerializeField] private float saludMax = 3f;
	[SerializeField] private bool destruirAlMorir = true;
	[SerializeField] private float tiempoEnDestruirse = 0f;
	[SerializeField] private float TMPInmunidad = 0.1f;
	[SerializeField] private UnityEvent<float> alPerderSalud;
	[SerializeField] private UnityEvent alMorir;

	MaterialDestello material;
	SpriteRenderer render;

	public float saludActual;
	private Animator animator;
	private bool estaMuerto = false;

	private bool esinmune;

	public event Action alActualizarSalud;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		saludActual = saludMax;
	}
    private void Update()
    {
        if(saludActual > saludMax)
		{
			saludActual = saludMax;
		}
    }
    private void Start()
	{
		render = GetComponent<SpriteRenderer>();
		material= GetComponent<MaterialDestello>();
		alActualizarSalud?.Invoke();
		
	}
	
	public bool EstaMuerto()
	{
		return estaMuerto;
	}

	public float ObtenerFraccion()
	{
		return saludActual / saludMax;
	}

	public float ObtenerSalud()
	{
		return saludActual;
	}

	public void AjustarSalud(float salud)
	{
		saludActual = salud;
		alActualizarSalud?.Invoke();
	}
	IEnumerator inmunidad()
	{
		esinmune = true;
		render.material = material.destello;
		yield return new WaitForSeconds(TMPInmunidad);
		render.material = material.original;
		esinmune= false;
	}

	public void PerderSalud(float saludPerdida)
	{
		
			saludActual = Mathf.Max(saludActual - saludPerdida, 0);
			alPerderSalud?.Invoke(saludPerdida);
			alActualizarSalud?.Invoke();
		

			if (saludActual == 0)
			{
				Morir();
			}
			else
			{
				//animator.SetTrigger("perderSalud");
			}
		
	}

	public void PerderSaludJugador(float saludPerdida)
	{
		//animator.ResetTrigger("perderSalud");
		if (!esinmune)
		{
			saludActual = Mathf.Max(saludActual - saludPerdida, 0);
			alPerderSalud?.Invoke(saludPerdida);
			alActualizarSalud?.Invoke();
            StartCoroutine(inmunidad());

            if (saludActual == 0)
			{
				Morir();
			}
			else
			{
				//animator.SetTrigger("perderSalud");
			}
		}
	}

	private void Morir()
	{
		if (estaMuerto) return;

		alMorir?.Invoke();
		estaMuerto = true;
		//animator.SetTrigger("morir");
		if (destruirAlMorir)
		{
			Destroy(gameObject, tiempoEnDestruirse);
		}
	}

  public void RecuperarVida(float vida)
	{
		saludActual += vida;
        alActualizarSalud?.Invoke();
    }
}


