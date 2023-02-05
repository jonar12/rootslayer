using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public GameObject jugador;
    [SerializeField] public float velocidadMov;
    [SerializeField] private float daño;
    [SerializeField] public float distanciaDeteccion;
    [SerializeField] public float vida;
    private float distancia;
    private Rigidbody2D rigidBody;
    private Vector2 movimiento;

    // private float distanciaMin;    
    private CombateJugador combateJugador;

    void Start(){
        // distanciaMin = 0.5f;
        jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null) {
            combateJugador = jugador.GetComponent<CombateJugador>();   
        }
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(jugador == null) {
            DestroyAllEnemies();
            return;
        }
        distancia = Vector2.Distance(transform.position, jugador.transform.position);
        Vector3 direccion = jugador.transform.position - transform.position;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        rigidBody.rotation = angulo;
        direccion.Normalize();
        movimiento = direccion;

        // if(distancia < distanciaDeteccion) {
        //     transform.position = Vector2.MoveTowards(this.transform.position, jugador.transform.position, velocidad * Time.deltaTime);
        //     transform.rotation = Quaternion.Euler(Vector3.forward * angulo);
        // }
    }

    public void TomarDaño(float daño) {
        vida -= daño;
        if (vida <= 0) {
            Destroy(gameObject);
        }
    }

    public void DestroyAllEnemies() {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in allEnemies) {
            Destroy(enemy);
        }
    }

    private void OnCollisionEnter2D(Collision2D colision) {
        if(colision.gameObject.tag == "Player" && jugador != null) {
            combateJugador.TomarDaño(daño);
    }
    }

    private void moveCharacter(Vector2 direccion) {
        rigidBody.MovePosition((Vector2)transform.position + (direccion * velocidadMov * Time.deltaTime));
    }
    private void FixedUpdate() {
        moveCharacter(movimiento);
    }
}
