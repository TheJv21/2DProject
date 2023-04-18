using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWord : MonoBehaviour
{
    [SerializeField] private string mensaje;
    public GameObject Objetomover;
    public Transform Startpoint;
    public Transform EndPoint;
    public float Velocidad;
    private Vector3 MoverHacia; 

    // Start is called before the first frame update
    void Start()
    {
        MoverHacia = EndPoint.position; 
    }

    void Update()
    {
        Objetomover.transform.position = Vector3.MoveTowards(Objetomover.transform.position, MoverHacia, Velocidad * Time.deltaTime);
        if (Objetomover.transform.position == EndPoint.position)
        {
            MoverHacia = Startpoint.position;
        }
        if (Objetomover.transform.position == Startpoint.position)
        {
            MoverHacia = EndPoint.position;
        }
    }
    // Update is called once per frame
    public void Saludar()
    {
        Debug.Log(mensaje);
    }
}
