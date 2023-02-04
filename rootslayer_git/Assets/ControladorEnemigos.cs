using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControladorEnemigos : MonoBehaviour
{
    private float minX, maxX, minY, maxY; 
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempoEnemigos;

    private float tiempoSiguienteEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        minY = puntos.Min(punto => punto.position.y);
        maxY = puntos.Max(punto => punto.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoSiguienteEnemigo += Time.deltaTime;

        if(tiempoSiguienteEnemigo >= tiempoEnemigos) {
            tiempoSiguienteEnemigo = 0;
            // Crear enemigo
            CrearEnemigo();
        }
    }

    private void CrearEnemigo() {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionRandom = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemigos[numeroEnemigo], posicionRandom, Quaternion.identity);

    }
}
