using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCuadrado : MonoBehaviour
{

    public HelloWord variable;
    // Start is called before the first frame update
    void Start()
    {
        variable = GetComponent<HelloWord>();
        variable.Saludar();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
