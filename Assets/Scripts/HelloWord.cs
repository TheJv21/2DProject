using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWord : MonoBehaviour
{
    [SerializeField] private string mensaje;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void Saludar()
    {
        Debug.Log(mensaje);
    }
}
