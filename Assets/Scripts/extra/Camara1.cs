using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara1 : MonoBehaviour
{
    public GameObject jugador;
    private Vector3 posicion;
    // Start is called before the first frame update
    void Start()
    {
        posicion = transform.position - jugador.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = jugador.transform.position + posicion;
    }
}
