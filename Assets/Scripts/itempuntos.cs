using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itempuntos : MonoBehaviour
{

    [SerializeField] private int puntosBrindados = 100;
    [SerializeField] private AudioClip audioClip;
    private SpriteRenderer spriterender;

    private bool activado = false;
    private AudioSource audiosource;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        spriterender = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activado) { return; }

        if (collision.gameObject.TryGetComponent<Puntos>(out Puntos puntos))
        {
            activado = true;
            puntos.SumarPuntos(puntosBrindados);
            spriterender.enabled = false;
            Destroy(gameObject, audioClip.length);
        }

        if (audioClip == null) { return; }
        ReproducirSonido();

    }

    private void ReproducirSonido()
    {
        audiosource.PlayOneShot(audioClip);
    }
}
