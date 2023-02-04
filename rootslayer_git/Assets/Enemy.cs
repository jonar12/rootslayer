using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public GameObject jugador;
    public float velocidad;
    public float distancia;
    public float distanciaDeteccion;
    public float distanciaMin;    

    void Start(){
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        distancia = Vector2.Distance(transform.position, jugador.transform.position);
        Vector2 direccion = jugador.transform.position - transform.position;
        direccion.Normalize();
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        if(distancia < distanciaDeteccion && distancia > distanciaMin) {
            transform.position = Vector2.MoveTowards(this.transform.position, jugador.transform.position, velocidad * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angulo);
        }
    }
}
