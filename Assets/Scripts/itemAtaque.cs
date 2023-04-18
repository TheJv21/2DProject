using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemAtaque : MonoBehaviour
{
    [SerializeField] private float ataqueMejorado = 3f;
    [SerializeField] private float TMPBoost = 30f;
    //[SerializeField] private AudioClip audioClip;
    private SpriteRenderer spriterender;

    private bool activado = false;
    //private AudioSource audiosource;

    private void Start()
    {
        //audiosource = GetComponent<AudioSource>();
        spriterender = GetComponent<SpriteRenderer>();
        


    }

    IEnumerator Esperar(Collider2D collision)
    {
        IAtaque Ataque = collision.GetComponent<IAtaque>();
        Debug.Log("Ataque itemAtaque: "+Ataque.ataque);
        Debug.Log("Inicio IEnumerator");
        yield return new WaitForSeconds(TMPBoost);
        Ataque.ataque = 1f;
        Debug.Log("Final IEnumerator");
        Debug.Log("Ataque itemAtaque: " + Ataque.ataque);
        Destroy(gameObject/*, audioClip.length*/);
    }


   

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (activado) { return; }
        if (collision.gameObject.TryGetComponent<Puntos>(out Puntos puntos))
        {

            IAtaque Ataque = collision.GetComponent<IAtaque>();
            if (Ataque != null)
            {
                Ataque.ataque = ataqueMejorado;
            }
            activado = true;
            spriterender.enabled = false;
            StartCoroutine(Esperar(collision));

        }

        //if (audioClip == null) { return; }
        //ReproducirSonido();

    }

    //private void ReproducirSonido()
    //{
    //    audiosource.PlayOneShot(audioClip);
    //}
}
