using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas : MonoBehaviour
{
    public GameObject MoverObjetor;
    public Transform PuntoInicio;
    public Transform PuntoFinal;
    public float Velocidad;
    private Vector3 MoverHacia;

    // Start is called before the first frame update
    void Start()
    {
        MoverHacia = PuntoFinal.position;
    }

    void Update()
    {
        MoverObjetor.transform.position = Vector3.MoveTowards(MoverObjetor.transform.position, MoverHacia, Velocidad * Time.deltaTime);
        if (MoverObjetor.transform.position == PuntoFinal.position)
        {
            MoverHacia = PuntoInicio.position;
        }
        if (MoverObjetor.transform.position == PuntoInicio.position)
        {
            MoverHacia = PuntoFinal.position;
        }
    }
    // Update is called once per frame
    
}
