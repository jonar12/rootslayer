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
    [SerializeField] private float tiempoMinEnemigos;
    [SerializeField] private float tiempoMaxEnemigos;
    [SerializeField] private int numEnemigos;
    [SerializeField] private int minNumEnemigos;
    [SerializeField] private int maxNumEnemigos;
    public float timeToOff = 10f;
    private float tiempoSiguienteEnemigo;
    [SerializeField] public GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        minY = puntos.Min(punto => punto.position.y);
        maxY = puntos.Max(punto => punto.position.y);
        tiempoEnemigos = 0.5f;
        numEnemigos = Random.Range(minNumEnemigos, maxNumEnemigos);
    }

    // Update is called once per frame
    void Update()
    {
        // if (timeToOff > 0) {
        //     timeToOff -= Time.deltaTime;
        // }
        tiempoSiguienteEnemigo += Time.deltaTime;

        if(tiempoSiguienteEnemigo >= tiempoEnemigos &&timer.GetComponent<TimerScript>().TimeLeft > 0) {
            tiempoSiguienteEnemigo = 0;
            tiempoEnemigos = getTiempoEnemigosRandom(tiempoMinEnemigos, tiempoMaxEnemigos);
            // Crear enemigo
            for (int i = 0; i < numEnemigos; i++) {
                CrearEnemigo();
            }
            numEnemigos = Random.Range(minNumEnemigos, maxNumEnemigos);
        }
    }

    private void CrearEnemigo() {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionRandom = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemigos[numeroEnemigo], posicionRandom, Quaternion.identity);

    }

    private float getTiempoEnemigosRandom(float min, float max) {
        return Random.Range(min,max);
    }

    public float getTimeToOff() {
        return timeToOff;
    }

}
